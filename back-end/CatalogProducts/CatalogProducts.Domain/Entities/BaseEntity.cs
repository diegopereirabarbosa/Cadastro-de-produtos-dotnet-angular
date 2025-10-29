
namespace CatalogProducts.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdate { get; set; }
        public DateTimeOffset DateDelete { get; set; }
    }
}
