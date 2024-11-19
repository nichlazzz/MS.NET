using Microsoft.AspNetCore.Identity;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.BL.Auth.Entities;

public class UserModel : IdentityUser<int>
{
    public Guid Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
    public string Name { get; set; }
    public ICollection<OrderModel> Orders { get; set; }
    public ICollection<FavoriteDishModel> FavoriteDishes { get; set; }
}
