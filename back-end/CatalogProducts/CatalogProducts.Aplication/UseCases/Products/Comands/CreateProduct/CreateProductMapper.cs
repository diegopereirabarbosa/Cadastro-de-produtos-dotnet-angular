using AutoMapper;
using CatalogProducts.Aplication.UseCases.Products.Comands.CreateProduct;
using CatalogProducts.Aplication.UseCases.Products.Models;
using CatalogProducts.Domain.Entities;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.Comands.CreateProduct
{
    public sealed class CreateProductMapper : Profile
    {
       public CreateProductMapper()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
