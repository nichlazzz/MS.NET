using Restoraunt.Restoraunt.BL.Dishes.Entities;

namespace Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;

public class CreateFavoriteDishModel : CreateDishModel
{
    public string Description { get; set; }
    public int IdUser { get; set; }
}
