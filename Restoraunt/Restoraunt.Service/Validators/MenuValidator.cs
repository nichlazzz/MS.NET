using FluentValidation;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.Validators
{
    public class MenuValidator : AbstractValidator<Menu>
    {
        public MenuValidator()
        {
            RuleFor(x => x.IdDish)
                .GreaterThan(0).WithMessage("Dish ID must be greater than zero.");

            RuleFor(x => x.IdAdmin)
                .GreaterThan(0).WithMessage("Admin ID must be greater than zero.");
        }
    }
}