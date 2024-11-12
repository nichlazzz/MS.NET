using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.BL.FavoriteDishes.Entities;

namespace Restoraunt.Restoraunt.BL.FavoriteDishes;

public interface IFavoriteDishProvider
{
    // Get all favorite dishes
    IEnumerable<FavoriteDishModel> GetFavoriteDishes();

    // Get a specific favorite dish by Id

    FavoriteDishModel GetFavoriteDishInfo(int id);

    // Get filtered favorite dishes
    IEnumerable<FavoriteDishModel> GetFavoriteDishes(FavoriteDishModelFilter filter);
}