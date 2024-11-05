using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IFavoriteDishesManager
{
    // Create a new favorite dish
    FavoriteDish CreateFavoriteDish(CreateFavoriteDishRequest model);
    // Update an existing favorite dish
    FavoriteDish UpdateFavoriteDish(int id, UpdateFavoriteDishRequest model);

    // Delete a favorite dish
    void DeleteFavoriteDish(int id);
}