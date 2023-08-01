using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Service.Dtos.Categories;
using WebApplication1.Service.Dtos.Products;
using WebApplication1.Service.Responses;
using WebApplication1.Service.Services.Interfaces;


namespace WebApplication1.Admin.Controllers
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
     private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ApiResponse result=await _categoryService.GetAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            ApiResponse result = await _categoryService.GetAsync(Id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryPostDto dto)
        {
            var result = await _categoryService.CreateAsync(dto);
            return StatusCode(result.StatusCode,result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdateDto dto)
        {
            var result = await _categoryService.UpdateAsync(id,dto);
            return StatusCode(result.StatusCode, result);
        }

 
    }
}
