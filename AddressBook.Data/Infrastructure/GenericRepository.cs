using AddressBook.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBook.Data.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
     where TEntity : class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        private DbSet<TEntity> Set => context.Set<TEntity>();

        public TEntity Add(TEntity entity)
        {
            if ((object)entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return context.Add<TEntity>(entity).Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if ((object)entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            await context.AddRangeAsync(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if ((object)entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            context.RemoveRange(entities);
        }

        public T AttachEntity<T>(T entity)
            where T : class
        {
            if ((object)entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return context.Attach<T>(entity).Entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return (IQueryable<TEntity>)Set;
        }

        public void Remove(TEntity entity)
        {
            if ((object)entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            ThrowIfNotTracked(entity);
            Set.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync(new CancellationToken());
        }

        public TEntity Update(TEntity entity)
        {
            if ((object)entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.context.Entry(entity).State = EntityState.Modified;
            ThrowIfNotTracked(entity);
            return entity;
        }

        private void ThrowIfNotTracked(TEntity entity)
        {
            if (context.Entry<TEntity>(entity).State == EntityState.Detached)
            {
                throw new InvalidOperationException("Entity is not tracked.");
            }
        }
    }
}
