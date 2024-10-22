using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Restoraunt.Restoraunt.DataAccess;

[Table("users")]
public class User : BaseEntity
{
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
    public string Name { get; set; }
    
    // public int OrderId { get; set; }
    public ICollection<Order> Orders { get; set; }
    // public int FavoriteDish { get; set; }
    public ICollection<FavoriteDish> FavoriteDishes { get; set; }
    
    public class UserRoleEntity : IdentityRole<int>
    {
    }
}