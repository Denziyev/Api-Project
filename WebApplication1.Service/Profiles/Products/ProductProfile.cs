

using AutoMapper;
using WebApplication1.Core.Entities;
using WebApplication1.Service.Dtos.Products;

namespace WebApplication1.Service.Profiles.Products
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductPostDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductGetDto>();
        }
    }
}
