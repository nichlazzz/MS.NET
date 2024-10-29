using System.ComponentModel.DataAnnotations;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;
public class CreateUserRequest : IValidatableObject
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    [MinLength(2)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    public string LastName { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        // Add any specific validation rules for your user creation, such as:
        // - Unique email address
        // - Password complexity requirements
        // - Other field-specific validations

        return errors;
    }
}
