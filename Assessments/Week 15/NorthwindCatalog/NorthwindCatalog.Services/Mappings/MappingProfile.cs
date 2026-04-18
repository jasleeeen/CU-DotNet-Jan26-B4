using AutoMapper;
using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Models;

namespace NorthwindCatalog.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => "/images/" + src.CategoryId + ".jpeg"));

            CreateMap<Product, ProductDTO>();
        }

    }
}
