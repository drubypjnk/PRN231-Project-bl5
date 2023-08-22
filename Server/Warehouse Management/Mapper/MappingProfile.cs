using AutoMapper;
using BussinessObject.DTO;
using BussinessObject.Models;

namespace Warehouse_Management.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
       
            CreateMap<Sku, SkuDTO>();
            CreateMap<Product, ProductFilterDTO>().
            ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.LastTestPrice, opt => opt.MapFrom(src => src.ProductVariants.OrderByDescending(x=>x.CreateDate).Select(s => s.UnitPrice).FirstOrDefault()))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.ProductVariants.Where(s=>s.DeleteFlag==false).Sum(x=> x.Quality)));

            CreateMap<User, UserDTO>();
        }
    }
}
