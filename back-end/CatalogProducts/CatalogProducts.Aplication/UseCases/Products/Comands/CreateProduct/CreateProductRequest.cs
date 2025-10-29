using CatalogProducts.Aplication.UseCases.Products.Models;
using MediatR;


namespace CatalogProducts.Aplication.UseCases.Products.Comands.CreateProduct
{
    public sealed record CreateProductRequest(string Name, string Description, decimal Price) : IRequest<ProductResponse>
    {

    }
}
