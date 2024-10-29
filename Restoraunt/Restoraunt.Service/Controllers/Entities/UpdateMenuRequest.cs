using System.ComponentModel.DataAnnotations;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;

public class UpdateMenuRequest
{
    [Required]
    public int IdMenu { get; set; }

    public int? IdAdmin { get; set; }

    public int? IdDish { get; set; }
}