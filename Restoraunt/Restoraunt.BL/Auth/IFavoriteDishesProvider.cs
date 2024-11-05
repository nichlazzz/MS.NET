using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IFavoriteDishesProvider
{
    // Get all favorite dishes
    IEnumerable<FavoriteDish> GetFavoriteDishes();

    // Get a specific favorite dish by Id
    FavoriteDish GetFavoriteDishInfo(int id);
    // Get filtered favorite dishes
    IEnumerable<FavoriteDish> GetFavoriteDishes(FavoriteDishesFilter filter); 
}