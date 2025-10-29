using CatalogProducts.Aplication.UseCases.Products.Models;
using MediatR;


namespace CatalogProducts.Aplication.UseCases.Products.Comands.DeleteProduct
{
    public sealed record DeleteProductRequest(int Id) : IRequest<ProductResponse>
    {

    }
}
