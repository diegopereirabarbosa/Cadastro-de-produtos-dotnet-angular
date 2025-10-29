using AutoMapper;
using CatalogProducts.Aplication.UseCases.Products.Models;
using CatalogProducts.Domain.Entities;
using CatalogProducts.Domain.Interfaces;
using MediatR;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, ProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            _productRepository.Create(product);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<ProductResponse>(product);
        }
    }
}
