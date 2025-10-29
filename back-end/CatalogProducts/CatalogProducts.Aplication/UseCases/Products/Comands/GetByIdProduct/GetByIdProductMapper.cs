using AutoMapper;
using CatalogProducts.Aplication.UseCases.Products.Models;
using CatalogProducts.Domain.Entities;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.GetByIdProduct
{
    public sealed class GetByIdProductMapper : Profile
    {
        public GetByIdProductMapper() {
            CreateMap<Product, ProductResponse>();
        }
    }
}
