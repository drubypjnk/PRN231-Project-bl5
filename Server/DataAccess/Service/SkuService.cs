using AutoMapper;
using BussinessObject.DTO;
using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class SkuService
    {
        private IMapper mapper;
        private PRN231_BL5Context context=new PRN231_BL5Context();

        public SkuService(IMapper mapper)
        {
            this.mapper = mapper;
        }

      

        public  List<SkuDTO> getAll()
        {
            List<SkuDTO> list = new List<SkuDTO>();
            List<Sku> skus = context.Skus.Include(x => x.ProductVariants).ToList();
            foreach (Sku sku in skus)
            {
                SkuDTO s = convertToDTO(sku);
                list.Add(s);
            }
            return list;
        }
        public SkuDTO convertToDTO(Sku sku)
        {
            SkuDTO s =mapper.Map<SkuDTO>(sku);
            List<ProductVariant> productVariants = sku.ProductVariants.GroupBy(x => x.ProductId).Select(g => g.First()).ToList();
            List<ProductDTO> productDTOs=new List<ProductDTO>();
            foreach (ProductVariant pv in productVariants)
            {
                ProductDTO productDTO = new ProductDTO();
                List<ProductVariant>pvs = context.ProductVariants.Where(x => x.ProductId == pv.ProductId).ToList();
                productDTO.ProductId = pv.ProductId;
                Product p=context.Products.FirstOrDefault(x => x.ProductId == pv.ProductId);
                if (p != null)
                {
                    productDTO.ProductName = p.ProductName;
                }
                productDTO.quality =pvs.Sum(x=>x.Quality);
                //add product
                productDTOs.Add(productDTO);
            }
            s.products=productDTOs;

            return s;

        }
        public Boolean createSku(SkuInforDTO model)
        {
            try
            {   
                //add sku
                Sku sku = new Sku();
                sku.CreateDate = model.CreateDate;
                sku.Name = model.Name;
                sku.Desc = model.Desc;
                DateTime currentDateTime = DateTime.Now;
                sku.CreateDate = currentDateTime;
                context.Skus.Add(sku);
                context.SaveChanges();

                //merge 2 list product type 
                List<ProductInforDTO> oldProductDto = model.Products.Where(x=>x.ProductId!=0).ToList();
                List<ProductInforDTO> newProductDto = model.Products.Where(x=>x.ProductId==0).ToList();
                List<ProductInforDTO>listDTO=new List<ProductInforDTO>();
                
                foreach(ProductInforDTO pd in newProductDto)
                {
                    Product p = ProductService.AddProductSku(pd);
                    pd.ProductId = p.ProductId;
                    listDTO.Add(pd);
                }
                listDTO.AddRange(oldProductDto);
                model.Products=listDTO;
               
                // add variant
                List<ProductVariant> productVariants = new List<ProductVariant>();
                model.Products.ForEach(x =>
                {
                    ProductVariant p = new ProductVariant();
                    p.SkuId = sku.SkuId;
                    p.ProductId = x.ProductId;
                    p.Quality = x.Quantity;
                    p.UnitPrice = x.UnitPrice;
                    p.UnitInStock = x.Quantity;
                    p.CreateDate = currentDateTime;
                    productVariants.Add(p);
                    context.ProductVariants.Add(p);
                    context.SaveChanges();
                    List<SubPosition> subPositions = ProductService.getPositions(x.Category, p.Quality);

                    if (subPositions.Count == 1) //have 1 position
                    {
                        SubPosition sp= context.SubPositions.FirstOrDefault(x => x.SubPositionId == subPositions[0].SubPositionId);
                        //SubPosition sp = subPositions[0];
                        sp.AvailSeat -= p.Quality;
                        //context.SubPositions.Update(subPositions[0]);
                        context.SaveChanges();
                    }
                    else
                    {
                        foreach (SubPosition subPosition in subPositions)
                        {
                            int? a = p.Quality;
                            if (a > 0 && a > subPosition.AvailSeat)
                            {
                                a -= subPosition.AvailSeat;
                                subPosition.AvailSeat = 0;
                                context.SubPositions.Update(subPosition);
                                context.SaveChanges();
                            }
                            if (a > 0 && a < subPosition.AvailSeat)
                            {
                                a = 0;
                                subPosition.AvailSeat -= a;
                                context.SubPositions.Update(subPosition);
                                context.SaveChanges();
                            }
                        }

                    }
                //add postion
                    foreach (SubPosition subPosition in subPositions)
                    {
                        ProductVariantsSubPositionRelation subP = new ProductVariantsSubPositionRelation(subPosition.SubPositionId, p.ProductVariantId, false);
                        context.ProductVariantsSubPositionRelations.Add(subP);
                        context.SaveChanges();
                    }
                });

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            //context.ProductVariants.AddRange(productVariants);
            //context.SaveChanges();
            return true;
        }

        public SkuResDTO getDetail(int skuId)
        {
            SkuResDTO skuInforDTO = new SkuResDTO();

            Sku? sku = context.Skus.Include(s=>s.ProductVariants).FirstOrDefault(x=>x.SkuId == skuId);
            skuInforDTO.Name = sku.Name;
            skuInforDTO.CreateDate = sku.CreateDate;
            skuInforDTO.Desc = sku.Desc;

            //PRODUCT
            List<ProductInforDTO> listP = new List<ProductInforDTO>();
            foreach (ProductVariant pv in sku.ProductVariants)
            {
               listP.Add(convertToProductInforDTO(pv));
                
            }

            skuInforDTO.Products = listP;
            skuInforDTO.TotalPrice = sku.TotalPrice;
            return skuInforDTO;
        }

         public ProductInforDTO convertToProductInforDTO(ProductVariant pv)
        {
            ProductInforDTO p=new ProductInforDTO();
            Product ? product=context.Products.Include(s=>s.Category).FirstOrDefault(x => x.ProductId == pv.ProductId);
           
            p.ProductId= product.ProductId;
            p.ProductName=product.ProductName;
            p.Image = product.Img;
            p.Category = product.Category.Name;
            p.UnitPrice = pv.UnitPrice;
            p.Quantity = pv.Quality;
            return p;
        }
        public Boolean updateProd(SkuEditDTO model)
        {
            try
            {
                ProductVariant? product = context.ProductVariants.Include(x=>x.Sku).
                    FirstOrDefault(x => x.ProductId == model.ProductId&&x.SkuId==model.skuId);
                int? o_total = product.Quality * product.UnitPrice;
           
                int? new_total = model.Quantity * model.Price;

                int? total = new_total - o_total;

                product.Quality = model.Quantity;
                product.UnitPrice = model.Price;

                Sku sku = product.Sku;
                if (sku.TotalPrice != null)
                {
                    sku.TotalPrice += total;
                }
                else
                {
                    sku.TotalPrice = total;
                }
                context.Skus.Update(sku);
                context.ProductVariants.Update(product);
                context.SaveChanges();

            }catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
