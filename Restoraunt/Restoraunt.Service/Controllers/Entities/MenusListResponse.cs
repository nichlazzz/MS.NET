using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;

public class MenusListResponse
{
    public List<MenuModel> Menus { get; set; }
}
