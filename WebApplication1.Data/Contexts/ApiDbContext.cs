

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Core.Entities;
using WebApplication1.Data.Configurations;

namespace WebApplication1.Data.Contexts
{
    public class ApiDbContext:IdentityDbContext<IdentityUser>
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
