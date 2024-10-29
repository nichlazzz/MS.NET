using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IMenusManager
{
    // Create a new menu
    Menu CreateMenu(CreateMenuRequest model);
    // Update an existing menu
    Menu UpdateMenu(int id, UpdateMenuRequest model);

    // Delete a menu
    void DeleteMenu(int id);
}
