using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;


public interface IMenusProvider
{
    // Get all menus
    IEnumerable<MenuModel> GetMenus();

    // Get a specific menu by Id
    MenuModel GetMenuInfo(int id);
    // Get filtered menus
    IEnumerable<MenuModel> GetMenus(MenusFilter filter);
}