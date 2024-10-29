using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IUserProvider
{
    // Get all admins
    IEnumerable<Admin> GetUsers();

    // Get a specific admin by Id
    Admin GetUserInfo(int id);

    // Get filtered admins
    IEnumerable<Admin> GetUsers(UsersFilter filter);
}