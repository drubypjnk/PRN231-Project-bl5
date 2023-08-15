using BussinessObject.Models;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProductVariant(ProductVariant variant)
        {
            
        }


        public List<ProductVariant> GetAllProductVariants() => ProductService.GetProduct();
        

        public ProductVariant GetProductById(int id) => ProductService.FindProductById(id);
        

        public void SaveProductVariant(ProductVariant variant)
        {
            try
            {
                using (var context = new PRN231_BL5Context())
                {
                    context.ProductVariants.Add(variant);
                    context.SaveChanges();
                }
            }catch (Exception ex)
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
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
