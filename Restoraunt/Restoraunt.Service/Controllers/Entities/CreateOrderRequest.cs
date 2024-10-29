using System.ComponentModel.DataAnnotations;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;


public class CreateOrderRequest : IValidatableObject
{
    [Required]
    public int IdUser { get; set; }

    [Required]
    public string Heading { get; set; }

    [Required]
    public DateTime DateCreate { get; set; }

    public string Details { get; set; }

    [Required]
    public List<int> DishIds { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        // Добавьте валидации для других свойств, если требуется
        return errors;
    }
}