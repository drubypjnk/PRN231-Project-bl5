using BussinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace Warehouse_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<ProductVariant> GetProductById(int id) => _productRepository.GetProductById(id);

        [HttpGet]
        public ActionResult<IEnumerable<ProductVariant>> GetProduct() => _productRepository.GetAllProductVariants();
    }
}
