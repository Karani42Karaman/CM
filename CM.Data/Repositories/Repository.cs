using Microsoft.EntityFrameworkCore;
using CM.Core.Repositories;
 

namespace CM.Data.Repositories
{
    public class Repository<TEntity> : IRepositoriy<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public void CreateAsync(TEntity model)
        {
            try
            {
                Context.Set<TEntity>().AddAsync(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
        public ValueTask<TEntity> GetAsync(Guid id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public bool Remove(Guid id)
        {
            try
            {
                var model = GetAsync(id).Result;
                if (model != null)
                {
                    var state = Context.Set<TEntity>().Remove(model).State;
                    if (state == EntityState.Deleted)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }

        }

        public bool Update(TEntity model)
        {
            try
            {
                var state = Context.Set<TEntity>().Update(model).State;
                if (state == EntityState.Modified)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }
    }

}
