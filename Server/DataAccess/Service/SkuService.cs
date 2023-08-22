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
        public string createSku(SkuInforDTO model)
        {
            Sku sku =new Sku();
            sku.CreateDate = model.CreateDate;
            sku.Name = model.Name;
            sku.Desc=model.Desc;
            context.Skus.Add(sku);
            context.SaveChanges();

            List<ProductVariant> productVariants = new List<ProductVariant>();
            model.products.ForEach(x =>
            {
                ProductVariant p = new ProductVariant();
                p.SkuId = sku.SkuId;
                p.ProductId = x.ProductId;
                p.Quality = x.Quantity;
                p.UnitPrice = x.UnitPrice;
                p.UnitInStock = p.Quality;
                productVariants.Add(p);
            });
            context.ProductVariants.AddRange(productVariants);
            context.SaveChanges();
            return null;
        }
    }
}
