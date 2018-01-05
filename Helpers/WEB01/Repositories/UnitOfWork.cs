using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB01.Models;

namespace WEB01.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }

        public void RejectChanges()
        {
            var changedEntries = dbContext.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged);

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
