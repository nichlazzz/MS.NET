using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IDishesManager
{
    // Create a new dish
    Dish CreateDish(CreateDishRequest model);

    // Update an existing dish
    Dish UpdateDish(int id, UpdateDishRequest model);

    // Delete a dish
    void DeleteDish(int id);
}
