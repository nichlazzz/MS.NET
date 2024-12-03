using FluentValidation;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.Heading)
                .NotEmpty().WithMessage("Heading is required.");
            
            RuleFor(x => x.DateCreate)
                .NotEmpty().WithMessage("Date of creation is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date of creation must not be in the future.");
            
            RuleFor(x => x.Diches)
                .NotNull().WithMessage("Dishes cannot be null.");
            
            RuleFor(x => x.IdDish)
                .GreaterThan(0).WithMessage("Dish ID must be greater than zero.");

            RuleFor(x => x.IdUser)
                .GreaterThan(0).WithMessage("User ID must be greater than zero.");
        }
    }
}