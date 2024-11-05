using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IMenusManager
{
    // Create a new menu
    MenuModel CreateMenu(CreateMenuModel model);
    // Update an existing menu
    MenuModel UpdateMenu(int id, UpdateMenuModel model);

    // Delete a menu
    void DeleteMenu(int id);
}