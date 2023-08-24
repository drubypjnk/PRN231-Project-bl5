﻿using AutoMapper;
using BussinessObject.DTO;
using BussinessObject.Models;
using DataAccess.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class SkuController : ControllerBase
    {
        IMapper mapper;
        private SkuService service;
        public SkuController(IMapper mapper)
        {
            this.mapper = mapper;
            service = new SkuService(this.mapper);
            
        }

        [HttpGet("")]
        public ActionResult<List<SkuDTO>> getAll()
        {
            return service.getAll();
        }

        [HttpPost("create")]
        public ActionResult<string> CreateSKU([FromBody] SkuInforDTO model)
        {
            try{
                
            }catch(Exception e)
            {
                return Conflict(e.Message);
            }
                return Ok("create sucessfully") ;
        }
    }
}
