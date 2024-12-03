using FluentValidation;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.ExternalId)
                .NotEmpty().WithMessage("External ID is required.");
            
            RuleFor(x => x.ModificationTime)
                .NotEmpty().WithMessage("Modification time is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Modification time cannot be in the future.");
            
            RuleFor(x => x.CreationTime)
                .NotEmpty().WithMessage("Creation time is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Creation time cannot be in the future.");
            
            RuleFor(x => x.Orders)
                .NotNull().WithMessage("Orders cannot be null.");

            RuleFor(x => x.FavoriteDishes)
                .NotNull().WithMessage("Favorite dishes cannot be null.");
        }
    }
}