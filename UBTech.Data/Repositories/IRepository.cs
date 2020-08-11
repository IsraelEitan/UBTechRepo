using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UBTeach.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        
    }
}