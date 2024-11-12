using Restoraunt.Restoraunt.BL.Dishes.Entities;

namespace Restoraunt.Restoraunt.BL.Dishes;

public interface IDishManager
{
    // Create a new dish
    DishModel CreateDish(CreateDishModel model);

    // Update an existing dish
    DishModel UpdateDish(int id, UpdateDishModel model);

    // Delete a dish
    void DeleteDish(int id);
}
