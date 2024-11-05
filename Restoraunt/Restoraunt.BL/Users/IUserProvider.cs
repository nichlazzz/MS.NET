using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;
public interface IUserProvider
{
    // Get all admins
    IEnumerable<UserModel> GetUsers();

    // Get a specific admin by Id
    UserModel GetUserInfo(int id);

    // Get filtered admins
    IEnumerable<UserModel> GetUsers(UsersFilter filter);
}
