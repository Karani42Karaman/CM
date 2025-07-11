using CM.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core
{
    public  interface IUnitOfWork:IDisposable
    {
        IRepositoriy<Entity> IRepositoriy <Entity>() where Entity : class;

        Task<int> SaveChangesAsync();
          int SaveChanges();
    }
}
