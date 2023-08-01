
using WebApplication1.Service.Dtos.Categories;
using WebApplication1.Service.Responses;

namespace WebApplication1.Service.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<ApiResponse> CreateAsync(CategoryPostDto category);
        public Task<ApiResponse> UpdateAsync(int id,CategoryUpdateDto category);
        public Task<ApiResponse> GetAsync(int id);
        public Task<ApiResponse> GetAllAsync();
        public Task<ApiResponse> DeleteAsync(int id);
      
    }
}
