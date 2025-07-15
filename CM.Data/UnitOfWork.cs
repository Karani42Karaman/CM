using CM.Core;
using CM.Core.Repositories;
using CM.Data.Repositories;

namespace CM.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RCVDBContext _context;
        
        public UnitOfWork(RCVDBContext context)
        {
            _context = context;
         }

        public IRepositoriy<TEntity> IRepositoriy<TEntity>() where TEntity : class
        {
            

            var repository = new Repository<TEntity>(_context);
             return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }

}
