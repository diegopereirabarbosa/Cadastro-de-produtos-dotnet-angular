using CatalogProducts.Aplication.UseCases.Products.Comands.GetByIdProduct;
using FluentValidation;

namespace CatalogProducts.Application.UseCases.Products.Queries.GetByIdProduct
{
    public sealed class GetByIdProductValidator : AbstractValidator<GetByIdProductRequest>
    {
        public GetByIdProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O identificador do produto é obrigatório.");
        }
    }
}
