using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.BL.FavoriteDishes.Entities;

namespace Restoraunt.Restoraunt.BL.FavoriteDishes;

public interface IFavoriteDishManager
{
    // Create a new favorite dish
    FavoriteDishModel CreateFavoriteDish(CreateFavoriteDishModel model);

    // Update an existing favorite dish
    FavoriteDishModel UpdateFavoriteDish(int id, UpdateFavoriteDishModel model);

    // Delete a favorite dish
    void DeleteFavoriteDish(int id);
}

