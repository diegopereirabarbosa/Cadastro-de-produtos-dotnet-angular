using CatalogProducts.Aplication.UseCases.Products.Models;
using MediatR;


namespace CatalogProducts.Aplication.UseCases.Products.Comands.GetByIdProduct
{
    public sealed record GetByIdProductRequest(int Id) : IRequest<ProductResponse>;

}
