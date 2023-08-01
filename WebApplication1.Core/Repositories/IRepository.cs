
using System.Linq.Expressions;
using WebApplication1.Core.Entities;

namespace WebApplication1.Core.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task AddAsync(T entities);

        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T,bool>> expression,params string[] includes);


        public Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, params string[] includes);


        public Task Update(T entities);

        public Task Remove(T entities);


        public Task<int> SaveAsync();

        public int Save();

        public Task<bool> isExist(Expression<Func<T, bool>> expression);
    }
}
