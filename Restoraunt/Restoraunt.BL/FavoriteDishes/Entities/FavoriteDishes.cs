
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.BL.Dishes.Entities;

namespace Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;

public class FavoriteDishModel : DishModel // Inherit from DishModel
{
    public string Description { get; set; }
    public int IdUser { get; set; }
    public UserModel _User { get; set; }
}

