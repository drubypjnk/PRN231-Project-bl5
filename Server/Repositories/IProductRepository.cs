using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        ProductVariant GetProductById (int id);

        void SaveProductVariant (ProductVariant variant);
        void UpdateProductVariant (ProductVariant variant);
        void DeleteProductVariant (ProductVariant variant);

        List<ProductVariant> GetAllProductVariants ();
        List<ProductVariant> SearchProduct(string productName);

        List<ProductVariant> SearchFilterByCategory(int categoryId);

        List<ProductVariant> SearchFilterByType(int type);

        List<ProductVariant> SearchFilterByState(bool deleteFlag);

        void UpdateStatusProduct (bool deleteFlag, int id);
    }
}
