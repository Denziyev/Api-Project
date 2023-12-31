﻿namespace WebApplication1.Service.Dtos.Products
{
    public record ProductGetDto
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public string Image { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
