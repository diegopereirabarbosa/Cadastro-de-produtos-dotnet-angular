using CatalogProducts.Domain.Interfaces;
using CatalogProducts.Persistence.Context;

namespace CatalogProducts.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context) 
        {
            _context = context;
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
