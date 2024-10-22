using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Restoraunt.Restoraunt.DataAccess;
[Table("admins")]
public class Admin: User
{
    public string Email { get; set; }
    
    // public int IdMenu { get; set; }
    public ICollection<Menu> Menus { get; set; }
}
public class AdminRoleEntity : IdentityRole<int>
{
}