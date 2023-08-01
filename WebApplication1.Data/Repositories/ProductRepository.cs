using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Core.Entities;
using WebApplication1.Core.Repositories;
using WebApplication1.Data.Contexts;
using WebApplication1.Data.Repositories.Implementations;

namespace WebApplication1.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
