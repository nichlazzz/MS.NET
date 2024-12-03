using FluentValidation;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.Validators
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(x => x.Menus)
                .NotNull().WithMessage("Menus cannot be null.");
        }
    }
}