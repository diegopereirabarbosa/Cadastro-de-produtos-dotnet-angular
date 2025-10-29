using CatalogProducts.Aplication.UseCases.Products.Models;
using MediatR;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.UpdateProduct
{
    public sealed record UpdateProductRequest(int Id, string Name, string Description, decimal Price) : IRequest<ProductResponse>
    {

    }
}
