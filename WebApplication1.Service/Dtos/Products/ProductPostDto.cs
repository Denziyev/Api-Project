using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Service.Dtos.Products
{
    public record ProductPostDto
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public IFormFile File { get; set; }
        public int CategoryId { get; set; }
    }
}
