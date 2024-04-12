using API.DTOS;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductDTO>()
            .ForMember(dest => dest.ProductBrand, b => b.MapFrom(s => s.ProductBrand.Name))
            .ForMember(dest => dest.ProductType, b => b.MapFrom(s => s.ProductType.Name))
            .ForMember(dest => dest.PictureURL, b=>b.MapFrom<ProductURLResolver>());
        }
    }
}