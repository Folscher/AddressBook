using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data.Infrastructure
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        TEntity Add(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        T AttachEntity<T>(T entity) where T : class;

        IQueryable<TEntity> GetAll();

        void Remove(TEntity entity);

        Task<int> SaveChangesAsync();

        TEntity Update(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
