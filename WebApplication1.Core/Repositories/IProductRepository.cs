using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Core.Entities;
using WebApplication1.Core.Repositories.Interfaces;

namespace WebApplication1.Core.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
    }
}
