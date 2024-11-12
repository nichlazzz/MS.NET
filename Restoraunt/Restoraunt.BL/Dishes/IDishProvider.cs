using Restoraunt.Restoraunt.BL.Dishes.Entities;

namespace Restoraunt.Restoraunt.BL.Dishes;

public interface IDishProvider
{
    // Get all dishes
    IEnumerable<DishModel> GetDishes();

    // Get a specific dish by Id
    DishModel GetDishInfo(int id);

    // Get filtered dishes
    IEnumerable<DishModel> GetDishes(DishModelFilter filter);
}
