using AutoMapper;
using BussinessObject.Models;

namespace Warehouse_Management.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
       

            CreateMap<Sku, SkuDTO>();
        }
    }
}
