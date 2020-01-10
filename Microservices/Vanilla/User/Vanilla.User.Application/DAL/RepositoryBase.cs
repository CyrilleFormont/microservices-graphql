using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vanilla.User.Persistence;

namespace Vanilla.User.Application.DAL
{
    public interface IBaseRepository<TEntity, in TKey>
        where TEntity : class
    {
        Task<List<TEntity>> GetAll();

        Task<List<TEntity>> GetAll(string include);

        Task<List<TEntity>> GetAll(IEnumerable<string> includes);

        Task<TEntity> Get(TKey id);

        Task<TEntity> Get(TKey id, string include);

        Task<TEntity> Get(TKey id, IEnumerable<string> includes);
        TEntity Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Delete(TKey id);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        Task<bool> SaveChangesAsync();
    }

    public abstract class RepositoryBase<TEntity, TKey> :  IBaseRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
    {
        private readonly UserContext dbContext;
        protected RepositoryBase(UserContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            return this.dbContext.Set<TEntity>().ToListAsync();
        }

        public Task<List<TEntity>> GetAll(string include)
        {
            return this.dbContext.Set<TEntity>().Include(include).ToListAsync();
        }

        public Task<List<TEntity>> GetAll(IEnumerable<string> includes)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.ToListAsync();
        }

        public virtual Task<TEntity> Get(TKey id)
        {
            return this.dbContext.Set<TEntity>().SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, string include)
        {
            return this.dbContext.Set<TEntity>().Include(include).SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, IEnumerable<string> includes)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public virtual TEntity Add(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.dbContext.Set<TEntity>().AddRange(entities);
        }

        public virtual void Delete(TKey id)
        {
            var entity = new TEntity { Id = id };
            this.dbContext.Set<TEntity>().Attach(entity);
            this.dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return (await this.dbContext.SaveChangesAsync()) > 0;
        }

        public virtual void Update(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Attach(entity);
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            this.dbContext.Set<TEntity>().UpdateRange(entities);
        }
    }
}
