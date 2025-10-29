using AutoMapper;
using CatalogProducts.Aplication.UseCases.Products.Models;
using CatalogProducts.Domain.Interfaces;
using MediatR;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, ProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public DeleteProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id, cancellationToken);
            if (product == null) return default;

            _productRepository.Delete(product);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<ProductResponse>(product);
        }
    }
}
