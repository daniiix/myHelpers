using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB01.Repositories
{
    public interface IUnitOfWork 
    {
        void Commit();

        void RejectChanges();

        void Dispose();
    }
}
