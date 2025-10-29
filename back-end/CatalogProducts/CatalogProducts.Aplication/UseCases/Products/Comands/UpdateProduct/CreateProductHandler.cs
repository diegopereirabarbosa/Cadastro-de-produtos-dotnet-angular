using AutoMapper;
using CatalogProducts.Aplication.UseCases.Products.Models;
using CatalogProducts.Domain.Interfaces;
using MediatR;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, ProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public UpdateProductHandler(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductResponse> Handle(UpdateProductRequest command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(command.Id, cancellationToken);
            if (product is null) return default;

            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;

            _productRepository.Update(product);

            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<ProductResponse>(product);
        }
    }
}
