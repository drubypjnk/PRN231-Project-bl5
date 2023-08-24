using AutoMapper;
using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse_Management.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		IMapper mapper;

        public CategoryController(IMapper mapper)
        {
            this.mapper = mapper;
        }

		[HttpGet("List")]
		public IActionResult GetAll()
		{
			CategoryService categoryService=new CategoryService(mapper);
			return Ok(categoryService.getAll());
		}
	}
}
