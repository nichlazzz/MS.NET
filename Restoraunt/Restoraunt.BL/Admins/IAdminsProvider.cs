using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.BL.Trainers.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IAdminsProvider
{
    // Get all admins
    IEnumerable<AdminModel> GetAdmins();

    // Get a specific admin by Id
    AdminModel GetAdminInfo(int id);
    // Get filtered admins
    IEnumerable<AdminModel> GetAdmins(AdminModelFilter filter);
}
