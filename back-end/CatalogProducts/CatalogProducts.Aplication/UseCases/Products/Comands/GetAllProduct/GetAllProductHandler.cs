using AutoMapper;
using CatalogProducts.Aplication.UseCases.Products.Models;
using CatalogProducts.Domain.Interfaces;
using MediatR;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.GetAllProduct
{
    public sealed class GetAllProductHandler : IRequestHandler<GetAllProductRequest, List<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll(cancellationToken);
            return _mapper.Map<List<ProductResponse>>(products);
        }

    }
}
