using CatalogProducts.Domain.Entities;
using CatalogProducts.Domain.Interfaces;
using CatalogProducts.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogProducts.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;
        public BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            entity.DateCreated = DateTime.Now;
            Context.Add(entity);
        }

        public void Update(T entity)
        {
           entity.DateUpdate = DateTime.Now;
            Context.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DateDelete = DateTime.Now;
            Context.Remove(entity);
        }

        public async Task<T> Get(int id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }


    }
}
