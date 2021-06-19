using System.Linq;
using AutoMapper;
using ECommerce.Api.DataAccess.Entities;

namespace ECommerce.Api.Setup
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Category, Model.Category>()
                .ForMember(e => e.Products,
                    e => e.MapFrom(x => x.ProductCategories.Select(c => c.Product).ToList()))
                .ReverseMap();
            CreateMap<Product, Model.Product>().ReverseMap();
            CreateMap<ProductCategory, Model.ProductCategory>().ReverseMap();
        }
    }
}
