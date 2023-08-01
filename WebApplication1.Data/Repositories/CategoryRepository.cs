using Microsoft.EntityFrameworkCore;
using WebApplication1.Core.Entities;
using WebApplication1.Core.Repositories.Interfaces;
using WebApplication1.Data.Contexts;
using WebApplication1.Data.Repositories.Implementations;

namespace WebApplication1.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
