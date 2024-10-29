using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IDishesProvider
{
    // Get all dishes
    IEnumerable<Dish> GetDishes();

    // Get a specific dish by Id
    Dish GetDishInfo(int id);

    // Get filtered dishes
    IEnumerable<Dish> GetDishes(DishesFilter filter);
}
