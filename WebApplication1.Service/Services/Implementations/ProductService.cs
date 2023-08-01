using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Core.Entities;
using WebApplication1.Core.Repositories;
using WebApplication1.Core.Repositories.Interfaces;
using WebApplication1.Service.Dtos.Products;
using WebApplication1.Service.Extentions;
using WebApplication1.Service.Responses;
using WebApplication1.Service.Services.Interfaces;

namespace WebApplication1.Service.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProductService(IProductRepository repository, IMapper mapper, IWebHostEnvironment env, ICategoryRepository categoryRepository, IHttpContextAccessor contextAccessor)
        {
            _repository = repository;
            _mapper = mapper;
            _env = env;
            _categoryRepository = categoryRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<ApiResponse> CreateAsync(ProductPostDto dto)
        {
            Category category = await _categoryRepository.GetByIdAsync(x=>x.Id==dto.CategoryId);
            if (category == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "This category was not found" };
            }
            if (await _repository.isExist(x => x.Name.Trim().ToLower() == dto.Name.Trim().ToLower()))
            {
                return new ApiResponse { StatusCode = 404, Description = $"{dto.Name} already exsist" };
            }
            Product product=_mapper.Map<Product>(dto);
            product.Image = dto.File.CreateImage(_env.WebRootPath, "assets/images/");
            product.ImageURL =  _contextAccessor.HttpContext.Request.Scheme + "://" + _contextAccessor.HttpContext.Request.Host+$"/assets/images/{product.Image}";
            await _repository.AddAsync(product);
            await _repository.SaveAsync();
            return new ApiResponse { StatusCode=201,items=product};
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
            if (product==null)
            {
                return new ApiResponse { StatusCode = 404, Description = "This product was not found" };
            }

            product.IsDeleted=true;
            await _repository.Update(product);
            await _repository.SaveAsync();
            return new ApiResponse { StatusCode=204,Description="This product deleted succesfully"};
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            IQueryable<Product> query = await _repository.GetAllAsync(x=>!x.IsDeleted,"Category");
            List<ProductGetDto> products = new List<ProductGetDto>();
            products = await query.Select(x => new ProductGetDto { Name = x.Name,ImageURL=x.ImageURL , Price=x.Price,Image=x.Image,CategoryId=x.CategoryId,CategoryName=x.Category.Name}).ToListAsync();

            return new ApiResponse { StatusCode=200,items=products};
        }

        public async Task<ApiResponse> GetAsync(int id)
        {
            Product product=await _repository.GetByIdAsync(x=>x.Id== id,"Category");
            if (product == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "This product was not found" };
            }

            ProductGetDto dto= _mapper.Map<ProductGetDto>(product);
            dto.CategoryName = product.Category.Name;
            return new ApiResponse { StatusCode = 200, items = dto };
        }

        public async Task<ApiResponse> UpdateAsync(int id, ProductUpdateDto dto)
        {
            Product product = await _repository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
            if (product == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "This product was not found" };
            }

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.UpdatedAt=DateTime.Now;
            product.CategoryId = dto.CategoryId;
            product.Image = dto.File == null ? product.Image : dto.File.CreateImage(_env.WebRootPath, "/assets/images/");

            await _repository.Update(product);
            await _repository.SaveAsync();
            return new ApiResponse { StatusCode = 204, Description = "Product changed succesfully", items = product };

        }
    }
}
