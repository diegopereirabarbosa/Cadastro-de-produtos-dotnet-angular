using AutoMapper;
using CatalogProducts.Aplication.UseCases.Products.Models;
using CatalogProducts.Domain.Entities;
namespace CatalogProducts.Aplication.UseCases.Products.Comands.DeleteProduct
{
    public sealed class DeleteProductMapper : Profile
    {
       public DeleteProductMapper()
        {
            CreateMap<DeleteProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
