using System.ComponentModel.DataAnnotations;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;

public class CreateMenuRequest : IValidatableObject
{
    [Required]
    public int IdAdmin { get; set; }

    [Required]
    public int IdDish { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        // Добавьте валидации для других свойств, если требуется
        return errors;
    }
}