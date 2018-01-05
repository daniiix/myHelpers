using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB01.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> 
        where TEntity: class 
        where TKey : struct
    {
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public virtual TEntity GetSingle(TKey id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
