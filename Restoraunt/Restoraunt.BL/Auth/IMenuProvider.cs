using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;


public interface IMenusProvider
{
    // Get all menus
    IEnumerable<Menu> GetMenus();

    // Get a specific menu by Id
    Menu GetMenuInfo(int id);
    // Get filtered menus
    IEnumerable<Menu> GetMenus(MenusFilter filter);
}
