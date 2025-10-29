using FluentValidation;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.CreateProduct
{
    public sealed class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotEmpty().WithMessage("O nome do produto é obrigatório.").MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(300).WithMessage("O tamanho máximo da descrição é 300 caracteres.");
            RuleFor(x => x.Price).NotNull().WithMessage("O preço é obrigatório.");
        }
    }
}
