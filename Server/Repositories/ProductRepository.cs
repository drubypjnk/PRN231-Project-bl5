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
            
        }

        public List<ProductVariant> SearchFilterByCategory(int categoryId) => ProductService.searchFilterByCategory(categoryId);

        public List<ProductVariant> SearchFilterByState(bool deleteFlag) => ProductService.searchFilterByState(deleteFlag);
        

        public List<ProductVariant> SearchFilterByType(int type) => ProductService.searchFilterByType(type);
        

        public List<ProductVariant> SearchProduct(string productName) => ProductService.searchProduct(productName);
        

        public void UpdateProductVariant(ProductVariant variant)
        {
            
        }

        public void UpdateStatusProduct(bool deleteFlag, int id) => ProductService.UpdateStatusProduct(deleteFlag, id);
        
    }
}
