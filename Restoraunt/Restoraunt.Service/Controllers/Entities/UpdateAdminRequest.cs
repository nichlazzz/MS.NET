using System.ComponentModel.DataAnnotations;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;
public class UpdateAdminRequest
{
    [Required]
    public int Id { get; set; }

    public string Email { get; set; }
}