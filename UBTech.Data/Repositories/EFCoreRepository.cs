using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UBTeach.Data.Models;

namespace UBTeach.Data.Repositories
{
    public class EFCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly PersonContext _myDBContext;

        public EFCoreRepository(PersonContext DBContext)
        {
            _myDBContext = DBContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _myDBContext.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _myDBContext.AddAsync(entity);
                await _myDBContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _myDBContext.Update(entity);
                await _myDBContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _myDBContext.Set<TEntity>().Where(predicate);
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }
    }
}