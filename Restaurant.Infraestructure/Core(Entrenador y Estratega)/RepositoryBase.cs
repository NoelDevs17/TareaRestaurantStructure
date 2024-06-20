

using Microsoft.EntityFrameworkCore;
using Restaurant.Infraestructure.Context;

namespace Restaurant.Infraestructure.Core
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected MyDbContext DbContext { get; set; }

        public RepositoryBase(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task Create(T entity)
        {
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}

