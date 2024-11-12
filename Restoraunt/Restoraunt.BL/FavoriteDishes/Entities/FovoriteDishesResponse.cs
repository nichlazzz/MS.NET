using Restoraunt.Restoraunt.BL.Dishes.Entities;
using UpdateDishModel = Restoraunt.Restoraunt.BL.Auth.Entities.UpdateDishModel;

namespace Restoraunt.Restoraunt.BL.FavoriteDishes.Entities;

public class UpdateFavoriteDishModel : UpdateDishModel
{
    public string Description { get; set; }
    public int IdUser { get; set; }
}

public class FavoriteDishModelFilter : DishModelFilter
{
    // Add any additional filter properties specific to FavoriteDish
    public int? IdUser { get; set; }
}
