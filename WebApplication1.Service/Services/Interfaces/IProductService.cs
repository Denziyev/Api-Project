using WebApplication1.Service.Dtos.Products;
using WebApplication1.Service.Responses;

namespace WebApplication1.Service.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ApiResponse> CreateAsync(ProductPostDto product);
        public Task<ApiResponse> UpdateAsync(int id,ProductUpdateDto product);
        public Task<ApiResponse> GetAsync(int id);
        public Task<ApiResponse> GetAllAsync();
        public Task<ApiResponse> DeleteAsync(int id);
      
    }
}
