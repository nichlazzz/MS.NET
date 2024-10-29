using System.ComponentModel.DataAnnotations;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;
public class UpdateOrderRequest
{
    [Required]
    public int Id { get; set; }

    public string Heading { get; set; }

    public DateTime DateCreate { get; set; }

    public string Details { get; set; }

    public List<int> DishIds { get; set; }
}