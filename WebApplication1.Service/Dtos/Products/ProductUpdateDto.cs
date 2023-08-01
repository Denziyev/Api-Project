﻿using Microsoft.AspNetCore.Http;

namespace WebApplication1.Service.Dtos.Products
{
    public record ProductUpdateDto
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public IFormFile File { get; set; }
        public int CategoryId { get; set; }
    }
}
