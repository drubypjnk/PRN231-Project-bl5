using AutoMapper;
using BussinessObject.DTO;
using BussinessObject.Models;
using DataAccess.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace Warehouse_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMapper mapper;
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            this.mapper = mapper;
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

        [HttpGet("getForModal/{category}/{status}")]
        public ActionResult<IEnumerable<ProductFilterDTO>> getForModal(int category,int status)
        {
            ProductService productService = new ProductService(mapper);

            List<ProductFilterDTO> products = productService.getForModal(category, status);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpPost("getProductByIds")]
        public ActionResult<IEnumerable<ProductFilterDTO>> getProductByIds(
            [FromBody]List<int>ids)
        {
            ProductService productService = new ProductService(mapper);

            List<ProductFilterDTO> products = productService.getProductByIds(ids);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

    }
}
