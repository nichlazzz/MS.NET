using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IAdminsProvider
{
    // Get all admins
    IEnumerable<Admin> GetAdmins();

    // Get a specific admin by Id
    Admin GetAdminInfo(int id);

    // Get filtered admins
    IEnumerable<Admin> GetAdmins(AdminsFilter filter);
}
