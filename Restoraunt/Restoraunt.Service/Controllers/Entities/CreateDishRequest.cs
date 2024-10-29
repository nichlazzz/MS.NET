using System.ComponentModel.DataAnnotations;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;
public class CreateDishRequest : IValidatableObject
{
    [Required]
    public string Category { get; set; }

    [Required]
    public decimal Cost { get; set; }

    public object Image { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        // Добавьте валидации для других свойств, если требуется
        return errors;
    }
}