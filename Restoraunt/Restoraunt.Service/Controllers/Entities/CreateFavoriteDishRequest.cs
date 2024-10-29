using System.ComponentModel.DataAnnotations;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;
public class CreateFavoriteDishRequest : IValidatableObject
{
    [Required]
    public int IdUser { get; set; }

    [Required]
    public int IdDish { get; set; }

    [Required]
    public string Descroption { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        // Добавьте валидации для других свойств, если требуется
        return errors;
    }
}