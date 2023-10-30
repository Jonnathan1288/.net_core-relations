using Api_Entity_Relations.Context;
using Microsoft.EntityFrameworkCore;

namespace Api_Entity_Relations.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PrincipalContext _principalContext;
        public Repository(PrincipalContext principalContext)
        {
            _principalContext = principalContext;
        }

        protected DbSet<T> EntitySet
        {
            get { return _principalContext.Set<T>(); }
        }

        public async Task<IEnumerable<T>> findAll()
        {
            return await EntitySet.ToListAsync();
        }
        public async Task<T> save(T entity)
        {
            EntitySet.Add(entity);
            await Save();
            return entity;
        }

        public async Task Save() { 
            await _principalContext.SaveChangesAsync();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _principalContext.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
