using AutoMapper;
using BussinessObject.Models;
using DataAccess.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private PositionService service;
        IMapper mapper;
        public PositionController()
        {
            service = new PositionService(this.mapper);

        }

        [HttpGet("GetALl/{categoryID}/{status}")]
        public ActionResult<List<ProductVariantsSubPositionRelation>> GetAllProductSubPosition(int categoryID, int status)
        {
            return service.GetAllProductSubPosition(categoryID, status);
        }

      /*  [HttpPost("CreatePosition")]
        public ActionResult<string> CreateSKU([FromBody] SkuInforDTO model)
        {
            try
            {
                Boolean check = service.createSku(model);
                if (check)
                {
                }
                else
                {
                    return Conflict("create failed !");

                }
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
            return Ok("create sucessfully");
        }*/
    }
}
