using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB01.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity GetSingle(TKey id);
        IQueryable<TEntity> GetAll();

        void Remove(TEntity entity);

        void Add(TEntity entity);

        void Update(TEntity entity);
    }
}
