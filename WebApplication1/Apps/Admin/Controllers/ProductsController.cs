using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication1.Service.Dtos.Categories;
using WebApplication1.Service.Dtos.Products;
using WebApplication1.Service.Services.Interfaces;

namespace WebApplication1.Admin.Controllers
{
    [Route("api/admin/[controller]/[action]")]
    [Authorize(Roles = "Admin,SuperAdmin")]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result=await _productService.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductPostDto dto)
        {
            var result = await _productService.CreateAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromForm]ProductUpdateDto dto)
        {
            var result= await _productService.UpdateAsync(id, dto);
            return StatusCode(result.StatusCode, result);
        }
    }
}
