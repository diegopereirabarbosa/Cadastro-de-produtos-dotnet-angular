using AutoMapper;
using CatalogProducts.Aplication.UseCases.Products.Models;
using CatalogProducts.Domain.Entities;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.UpdateProduct
{
    public sealed class UpdateProductMapper : Profile
    {
       public UpdateProductMapper()
        {
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
