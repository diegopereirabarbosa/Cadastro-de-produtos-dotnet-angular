using FluentValidation;

namespace CatalogProducts.Aplication.UseCases.Products.Comands.DeleteProduct
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
