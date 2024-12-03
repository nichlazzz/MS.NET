using System.Data.SqlTypes;
using FluentValidation;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.Validators
{
    public class DishValidator : AbstractValidator<Dish>
    {
        public DishValidator()
        {
            RuleFor(x => x.ExternalId)
                .NotEmpty().WithMessage("External ID is required.");
            
            RuleFor(x => x.Cost)
                .NotEmpty().WithMessage("Cost is required.")
                .GreaterThan(SqlMoney.Zero).WithMessage("Cost must be greater than zero.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.");

            RuleFor(x => x.Image)
                .NotNull().WithMessage("Image cannot be null.");
            
            RuleFor(x => x.Menus)
                .NotNull().WithMessage("Menus cannot be null.");
        }
    }
}