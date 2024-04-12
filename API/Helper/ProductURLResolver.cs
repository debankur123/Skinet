using API.DTOS;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class ProductURLResolver : IValueResolver<Product, ProductDTO, string>
    {
        public IConfiguration Config { get; }
        public ProductURLResolver(IConfiguration config)
        {
            this.Config = config;
        }

        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureURL)){
                return this.Config["ApiURL"] + source.PictureURL;
            }
            return null;
        }
    }
}