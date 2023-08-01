using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service.Dtos.Categories;
using WebApplication1.Service.Dtos.Products;
using WebApplication1.Service.Services.Interfaces;

namespace WebApplication1.Client.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result=await _productService.GetAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result=await _productService.GetAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
