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

        [HttpGet("Search/{productName}")]
        public ActionResult <IEnumerable<ProductVariant>> SearchProduct(string productName)
        {
            var products = _productRepository.SearchProduct(productName);
            if(products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("Filter/{categoryId}")]
        public ActionResult<IEnumerable<ProductVariant>> SearchFilterByCategory(int categoryId)
        {
            var products = _productRepository.SearchFilterByCategory(categoryId);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("FilterByType/{type}")]
        public ActionResult<IEnumerable<ProductVariant>> SearchFilterByType(int type)
        {
            var products = _productRepository.SearchFilterByType(type);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("FilterByState/{deleteFlag}")]
        public ActionResult<IEnumerable<ProductVariant>> SearchFilterByState(bool deleteFlag)
        {
            var products = _productRepository.SearchFilterByState(deleteFlag);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpPut("{id}/{deleteFlag}")]
        public IActionResult UpdateStatusProduct(bool deleteFlag, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _productRepository.UpdateStatusProduct(deleteFlag, id);
            return Ok();
        }
    }
}
