using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class ProductService
    {
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
    }
}
