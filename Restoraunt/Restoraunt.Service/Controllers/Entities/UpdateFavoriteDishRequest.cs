using System.ComponentModel.DataAnnotations;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;
public class UpdateFavoriteDishRequest
{
    [Required]
    public int Id { get; set; }

    public string Descroption { get; set; }
}