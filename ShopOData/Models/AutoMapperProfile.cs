using AutoMapper;
using ShopBussinessObject;
using ShopDTO;

namespace ShopOData.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(desc => desc.CategoryName, o => o.MapFrom(src => src.Category.CategoryName));
            CreateMap<Category, CategoryDTO>();
        }
    }
}
