using AutoMapper;
using BussinessObject.DTO;
using BussinessObject.Models;
using DataAccess.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		public IActionResult GetProductById(int id)
		{

			using (var context = new PRN231_BL5Context())
			{
				var list = context.ProductVariants.Include(p => p.Product).ThenInclude(a => a.Category).ThenInclude(c => c.Position).Where(x => x.ProductVariantId == id).Select(p => new
				{
					ProductVariantId = p.ProductVariantId,
					ProductId = p.ProductId,
					UnitPrice = p.UnitPrice,
					Quality = p.Quality,
					CreateBy = p.CreateBy,
					CreateDate = p.CreateDate,
					UpdateDate = p.UpdateDate,
					UnitInOrder = p.UnitInOrder,
					UnitInStock = p.UnitInStock,
					DeleteFlag = p.DeleteFlag,
					SkuId = p.SkuId,
					Position = p.Product.Category.Position.Address
				}).ToList();
				return Ok(list);
				if (list.Count == 0)
				{
					return NotFound();
				}
				return Ok(list);
			}
		}

		[HttpGet]
		public IActionResult GetProduct()
		{
			using (var context = new PRN231_BL5Context())
			{
				var list = context.ProductVariants.Include(p => p.Product).ThenInclude(a => a.Category).ThenInclude(c => c.Position).Select(p => new
				{
					ProductVariantId = p.ProductVariantId,
					ProductId = p.ProductId,
					UnitPrice = p.UnitPrice,
					Quality = p.Quality,
					CreateBy = p.CreateBy,
					CreateDate = p.CreateDate,
					UpdateDate = p.UpdateDate,
					UnitInOrder = p.UnitInOrder,
					UnitInStock = p.UnitInStock,
					DeleteFlag = p.DeleteFlag,
					SkuId = p.SkuId,
					Position = p.Product.Category.Position.Address
				}).ToList();
				if (list.Count == 0)
				{
					return NotFound();
				}
				return Ok(list);
			}
		}

		[HttpGet("Search/{productName}")]
		public IActionResult SearchProduct(string productName)
		{

			using (var context = new PRN231_BL5Context())
			{
				var list = context.ProductVariants.Include(p => p.Product).ThenInclude(a => a.Category).ThenInclude(c => c.Position).Where(x => x.Product.ProductName.Contains(productName)).Select(p => new
				{
					ProductVariantId = p.ProductVariantId,
					ProductId = p.ProductId,
					UnitPrice = p.UnitPrice,
					Quality = p.Quality,
					CreateBy = p.CreateBy,
					CreateDate = p.CreateDate,
					UpdateDate = p.UpdateDate,
					UnitInOrder = p.UnitInOrder,
					UnitInStock = p.UnitInStock,
					DeleteFlag = p.DeleteFlag,
					SkuId = p.SkuId,
					Position = p.Product.Category.Position.Address
				}).ToList();
				if (list.Count == 0)
				{
					return NotFound();
				}
				return Ok(list);
			}
		}

		[HttpGet("Filter/{categoryId}")]
		public IActionResult SearchFilterByCategory(int categoryId)
		{
			using (var context = new PRN231_BL5Context())
			{
				var list = context.ProductVariants.Include(p => p.Product).ThenInclude(a => a.Category).ThenInclude(c => c.Position).Where(x => x.Product.CategoryId == categoryId).Select(p => new
				{
					ProductVariantId = p.ProductVariantId,
					ProductId = p.ProductId,
					UnitPrice = p.UnitPrice,
					Quality = p.Quality,
					CreateBy = p.CreateBy,
					CreateDate = p.CreateDate,
					UpdateDate = p.UpdateDate,
					UnitInOrder = p.UnitInOrder,
					UnitInStock = p.UnitInStock,
					DeleteFlag = p.DeleteFlag,
					SkuId = p.SkuId,
					Position = p.Product.Category.Position.Address
				}).ToList();
				if (list.Count == 0)
				{
					return NotFound();
				}
				return Ok(list);
			}
		}

		[HttpGet("FilterByType/{type}")]
		public IActionResult SearchFilterByType(int type)
		{

			using (var context = new PRN231_BL5Context())
			{
				var list = context.ProductVariants.Include(p => p.Product).ThenInclude(a => a.Category).ThenInclude(c => c.Position).Where(x => x.UnitInStock > 0 && x.UnitInOrder == 0).Select(p => new
				{
					ProductVariantId = p.ProductVariantId,
					ProductId = p.ProductId,
					UnitPrice = p.UnitPrice,
					Quality = p.Quality,
					CreateBy = p.CreateBy,
					CreateDate = p.CreateDate,
					UpdateDate = p.UpdateDate,
					UnitInOrder = p.UnitInOrder,
					UnitInStock = p.UnitInStock,
					DeleteFlag = p.DeleteFlag,
					SkuId = p.SkuId,
					Position = p.Product.Category.Position.Address
				}).ToList();

				if (type == 1)
				{
					list = list.Where(x => x.UnitInStock > 0 && x.UnitInOrder == 0).ToList();
				}
				else if (type == 2)
				{
					list = list.Where(x => x.UnitInStock == 0 && x.UnitInOrder > 0).ToList();
				}
				list = list.ToList();
				if (list.Count == 0)
				{
					return NotFound();
				}
				return Ok(list);
			}
		}

		[HttpGet("FilterByState/{deleteFlag}")]
		public IActionResult SearchFilterByState(bool deleteFlag)
		{
			using (var context = new PRN231_BL5Context())
			{
				var list = context.ProductVariants.Include(p => p.Product).ThenInclude(a => a.Category).ThenInclude(c => c.Position).Where(x => x.UnitInStock > 0 && x.UnitInOrder == 0).Select(p => new
				{
					ProductVariantId = p.ProductVariantId,
					ProductId = p.ProductId,
					UnitPrice = p.UnitPrice,
					Quality = p.Quality,
					CreateBy = p.CreateBy,
					CreateDate = p.CreateDate,
					UpdateDate = p.UpdateDate,
					UnitInOrder = p.UnitInOrder,
					UnitInStock = p.UnitInStock,
					DeleteFlag = p.DeleteFlag,
					SkuId = p.SkuId,
					Position = p.Product.Category.Position.Address
				}).ToList();

				if (deleteFlag == true)
				{
					list = list.Where(x => x.DeleteFlag == true).ToList();
				}
				else if (deleteFlag == false)
				{
					list = list.Where(x => x.DeleteFlag == false).ToList();
				}
				list = list.ToList();
				if (list.Count == 0)
				{
					return NotFound();
				}
				return Ok(list);
			}
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
