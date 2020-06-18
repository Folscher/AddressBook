using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Service.Infrastructure
{
    public interface IGenericService<TEntity>
        where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entity);

        Task DeleteAsync(TEntity entity);

        IQueryable<TEntity> GetAll();

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}
