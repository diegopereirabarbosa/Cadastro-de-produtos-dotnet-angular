
using FluentValidation;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.UpdateProduct
{
    public sealed class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator() {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("O identificador do produto deve ser maior que zero.");
            RuleFor(x => x.Name).NotEmpty().NotEmpty().WithMessage("O nome do produto é obrigatório.").MaximumLength(50).MinimumLength(3);
            RuleFor(x => x.Description).MaximumLength(300).WithMessage("O tamanho máximo da descrição é 300 caracteres.");
            RuleFor(x => x.Price).NotNull().WithMessage("O preço é obrigatório.");
        }
    }
}
