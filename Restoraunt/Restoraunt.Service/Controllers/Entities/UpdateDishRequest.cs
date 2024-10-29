using System.ComponentModel.DataAnnotations;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;

public class UpdateDishRequest
{
    [Required]
    public int Id { get; set; }

    public string Category { get; set; }

    public decimal Cost { get; set; }

    public object Image { get; set; }
}