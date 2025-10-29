using AutoMapper;
using CatalogProducts.Aplication.UseCases.Products.Models;
using CatalogProducts.Domain.Interfaces;
using MediatR;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.GetByIdProduct
{
    public sealed class GetByIdProductHandler: IRequestHandler<GetByIdProductRequest, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetByIdProductHandler(IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponse> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetById(request.Id, cancellationToken);
            return _mapper.Map<ProductResponse>(products);
        }
    }
}
