using CatalogProducts.Domain.Entities;

namespace CatalogProducts.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetById(int id, CancellationToken cancellationToken);
    }
}
