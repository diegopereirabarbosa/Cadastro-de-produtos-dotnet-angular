using CatalogProducts.Domain.Entities;
using CatalogProducts.Domain.Interfaces;
using CatalogProducts.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogProducts.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetById(int id, CancellationToken cancellationToken)
        {
            return await Context.Procducts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);    
        }
    }
}
