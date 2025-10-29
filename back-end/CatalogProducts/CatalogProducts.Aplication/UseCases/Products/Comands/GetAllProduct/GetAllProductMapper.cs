using AutoMapper;
using CatalogProducts.Aplication.UseCases.Products.Models;
using CatalogProducts.Domain.Entities;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.GetAllProduct
{
    public sealed class GetAllProductMapper : Profile
    {
       public GetAllProductMapper()
        {
            CreateMap<Product, ProductResponse>();
        }
    }
}
