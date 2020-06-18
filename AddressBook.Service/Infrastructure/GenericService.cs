using AddressBook.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Service.Infrastructure
{
    public class GenericService<TEntity> : IGenericService<TEntity>
        where TEntity : class
    {
        private readonly IGenericRepository<TEntity> repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if ((object)entity == null) throw new ArgumentNullException("entity");
            OnAdd(repository, entity);
            repository.Add(entity);
            int num = await repository.SaveChangesAsync();
            return entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await repository.AddRangeAsync(entities);
            await repository.SaveChangesAsync();
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            if ((object)entity == null) throw new ArgumentNullException("entity");
            OnDelete(repository, entity);
            repository.Remove(entity);
            return (Task)repository.SaveChangesAsync();
        }

        public virtual Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            if ((object)entities == null) throw new ArgumentNullException("entity");
            repository.RemoveRange(entities);
            return (Task)repository.SaveChangesAsync();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if ((object)entity == null) throw new ArgumentNullException("entity");
            OnUpdate(repository, entity);
            repository.Update(entity);
            int num = await repository.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entity)
        {
            var range = entity.ToList();

            foreach (var entity1 in range)
            {

                if ((object)entity1 == null) throw new ArgumentNullException("entity");
                OnUpdate(repository, entity1);
                repository.Update(entity1);
            }

            int num = await repository.SaveChangesAsync();
        }

        protected virtual T AttachEntity<T>(T entity)
            where T : class
        {
            return repository.AttachEntity<T>(entity);
        }


        protected virtual void OnAdd(IGenericRepository<TEntity> repository, TEntity entity)
        {

        }

        protected virtual void OnDelete(IGenericRepository<TEntity> repository, TEntity entity)
        {
        }

        protected virtual void OnUpdate(IGenericRepository<TEntity> repository, TEntity entity)
        {
        }
    }
}
