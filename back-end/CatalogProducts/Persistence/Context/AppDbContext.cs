using CatalogProducts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogProducts.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        public DbSet<Product> Procducts { get; set; }
    }
}
