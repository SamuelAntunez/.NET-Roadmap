using FluentValidation;
using Frontend.Client;

namespace FrontEnd.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).("Maximo 100 caracteres");
            RuleFor(x => x.Cost)
                .GreaterThan(0).WithMessage("El costo debe ser mayor a 0");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0")
                .Must((product, price) => price > product.Cost).WithMessage("el precio debe ser mayor al costo");
        }
    }
}
