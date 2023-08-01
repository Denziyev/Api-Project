using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Core.Repositories.Interfaces;
using WebApplication1.Data.Contexts;

namespace WebApplication1.Data.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApiDbContext _context;
        public Repository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression, params string[] includes)
        {
            var query= _context.Set<T>().Where(expression);
            if (includes != null)
            {
                foreach(var include in includes)
                {
                    query=query.Include(include);
                }
            }
            return query;
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression,params string[] includes)
        {
            var query=  _context.Set<T>().Where(expression);
            if (includes != null)
            {
                foreach(var include in includes)
                {
                    query=query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> isExist(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public int Save()
        {
           return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
