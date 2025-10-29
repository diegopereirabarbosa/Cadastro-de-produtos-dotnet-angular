using CatalogProducts.Aplication.UseCases.Products.Models;
using MediatR;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.GetAllProduct
{
    public sealed record GetAllProductRequest() : IRequest<List<ProductResponse>>
    {

    }
}
