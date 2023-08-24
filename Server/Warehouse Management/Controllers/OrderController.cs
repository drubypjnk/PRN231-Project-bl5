using AutoMapper;
using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMapper mapper;
        private SkuService service;
        public OrderController(IMapper mapper)
        {
            this.mapper = mapper;
            service = new SkuService(this.mapper);

        }
        [HttpGet("")]
        public ActionResult<List<SkuDTO>> getAll()
        {
            return service.getAll();
        }

    }
}
