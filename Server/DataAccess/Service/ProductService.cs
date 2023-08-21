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
    public class ProductService
    {
        private IMapper mapper;

		public ProductService(IMapper mapper)
		{
			this.mapper = mapper;
		}

		public ProductService()
		{
		}

		public static List<ProductVariant> GetProduct()
        {   
            var list = new List<ProductVariant>();
            try
            {
                using(var context = new PRN231_BL5Context())
                {
                    list = context.ProductVariants.ToList();
                }
               
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static ProductVariant FindProductById(int productId)
        {
            ProductVariant variant = new ProductVariant();
            try
            {
                using(var context = new PRN231_BL5Context())
                {
                    variant = context.ProductVariants.SingleOrDefault(x => x.ProductVariantId == productId);
                }
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return variant;
        }

        public void SaveProduct(ProductVariant variant)
        {
            try
            {
                using (var context = new PRN231_BL5Context())
                {
                    context.ProductVariants.Add(variant);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProductVariant(ProductVariant variant)
        {
            try
            {
                using (var context = new PRN231_BL5Context())
                {
                    context.Entry<ProductVariant>(variant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<ProductVariant> searchProduct(string productName)
        {
            var products = new List<ProductVariant>();
            try
            {
                using(var context = new PRN231_BL5Context())
                {
                    products = context.ProductVariants.Include(x => x.Product).Where(x => x.Product.ProductName.Contains(productName)).Select(x => new ProductVariant
                    {
                        ProductVariantId = x.ProductVariantId,
                        ProductId = x.ProductId,
                        UnitPrice = x.UnitPrice,
                        Quality = x.Quality,
                        CreateDate = x.CreateDate,
                        UpdateDate = x.UpdateDate,
                        CreateBy = x.CreateBy,
                        UnitInStock = x.UnitInStock,
                        UnitInOrder = x.UnitInOrder,
                        DeleteFlag = x.DeleteFlag,
                        SkuId = x.SkuId
                    }).ToList();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }


        public static List<ProductVariant> searchFilterByCategory(int CategoryId)
        {
            var products = new List<ProductVariant>();
            try
            {
                using (var context = new PRN231_BL5Context())
                {
                    products = context.ProductVariants.Include(x => x.Product).Where(x => x.Product.CategoryId == CategoryId).Select(x => new ProductVariant
                    {
                        ProductVariantId = x.ProductVariantId,
                        ProductId = x.ProductId,
                        UnitPrice = x.UnitPrice,
                        Quality = x.Quality,
                        CreateDate = x.CreateDate,
                        UpdateDate = x.UpdateDate,
                        CreateBy = x.CreateBy,
                        UnitInStock = x.UnitInStock,
                        UnitInOrder = x.UnitInOrder,
                        DeleteFlag = x.DeleteFlag,
                        SkuId = x.SkuId
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static List<ProductVariant> searchFilterByType(int type)
        {
            var products = new List<ProductVariant>();
            try
            {
                using (var context = new PRN231_BL5Context())
                {
                    products = context.ProductVariants.ToList();
                    if(type == 1)
                    {
                        products = products.Where(x => x.UnitInStock >0 && x.UnitInOrder == 0).ToList();
                    }else if(type == 2)
                    {
                        products = products.Where(x => x.UnitInStock == 0 && x.UnitInOrder >0).ToList();    
                    }
                    products = products.Select(x => new ProductVariant
                    {
                        ProductVariantId = x.ProductVariantId,
                        ProductId = x.ProductId,
                        UnitPrice = x.UnitPrice,
                        Quality = x.Quality,
                        CreateDate = x.CreateDate,
                        UpdateDate = x.UpdateDate,
                        CreateBy = x.CreateBy,
                        UnitInStock = x.UnitInStock,
                        UnitInOrder = x.UnitInOrder,
                        DeleteFlag = x.DeleteFlag,
                        SkuId = x.SkuId
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static List<ProductVariant> searchFilterByState(bool deleteFlag)
        {
            var products = new List<ProductVariant>();
            try
            {
                using (var context = new PRN231_BL5Context())
                {
                    products = context.ProductVariants.ToList();
                    if (deleteFlag == true)
                    {
                        products = products.Where(x => x.DeleteFlag == true).ToList();
                    }
                    else 
                    {
                        products = products.Where(x => x.DeleteFlag == false).ToList();
                    }
                    products = products.Select(x => new ProductVariant
                    {
                        ProductVariantId = x.ProductVariantId,
                        ProductId = x.ProductId,
                        UnitPrice = x.UnitPrice,
                        Quality = x.Quality,
                        CreateDate = x.CreateDate,
                        UpdateDate = x.UpdateDate,
                        CreateBy = x.CreateBy,
                        UnitInStock = x.UnitInStock,
                        UnitInOrder = x.UnitInOrder,
                        DeleteFlag = x.DeleteFlag,
                        SkuId = x.SkuId
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static void UpdateStatusProduct(bool deleteFlag, int id)
        {
            using(var context = new PRN231_BL5Context())
            {
                var products = context.ProductVariants.Find(id);
                if(products != null)
                {
                    products.DeleteFlag = deleteFlag;
                    context.ProductVariants.Update(products);
                    context.SaveChanges();
                }
            }
        }
        
        public  List<ProductFilterDTO> getForModal(int category, int status)
		{
            var context = new PRN231_BL5Context();
            List<ProductFilterDTO> list = new List<ProductFilterDTO>();
            List<Product> products = new List<Product>();
			if (category == 0 && status == 0)
			{
                products=context.Products.Include(x => x.Category).Include(x=>x.ProductVariants).ToList();
			}
			else if(status == 0) //all status
			{
                products= context.Products.Include(x => x.Category).Include(x => x.ProductVariants)
                    .Where(x=>x.CategoryId==category).ToList();
            }else if (status == 0)
			{
                products = context.Products.Include(x => x.Category).Include(x => x.ProductVariants)
                  .Where(x => x.DeleteFlag == (status==1)).ToList();
			}
			else
			{
                products = context.Products.Include(x => x.Category).Include(x => x.ProductVariants)
                  .Where(x => (x.DeleteFlag == (status == 1))&&x.CategoryId==category).ToList();
            }
              list=mapper.Map<List<ProductFilterDTO>>(products);
            return list;
		}

        public List<ProductFilterDTO> getProductByIds(List<int> ids)
        {
            var context = new PRN231_BL5Context();
            List<ProductFilterDTO> list = new List<ProductFilterDTO>();
            List<Product> products = new List<Product>();
            foreach (int id in ids)
            {
                Product? product = context.Products
                    .Include(x => x.Category)
                    .Include(x => x.ProductVariants)
                    .FirstOrDefault(x => x.ProductId == id);
                if (product != null)
                {
                    products.Add(product);
                }
            }

            list = mapper.Map<List<ProductFilterDTO>>(products);
            return list;
        }

    }
}
