using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Repositories
{
    public interface IRepositoriy<TEntity> where TEntity : class
    {
        void CreateAsync(TEntity model);
        bool Update(TEntity model);
        bool Remove(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        ValueTask<TEntity> GetAsync(Guid id);
    }
}
