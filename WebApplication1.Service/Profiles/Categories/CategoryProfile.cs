

using AutoMapper;
using WebApplication1.Core.Entities;
using WebApplication1.Service.Dtos.Categories;

namespace WebApplication1.Service.Profiles.Categories
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryGetDto>();
        }
    }
}
