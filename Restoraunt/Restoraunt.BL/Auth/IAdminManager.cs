using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;


public interface IAdminsManager
{
    // Create a new admin
    Admin CreateAdmin(CreateAdminRequest model);

    // Update an existing admin
    Admin UpdateAdmin(int id, UpdateAdminRequest model);

    // Delete an admin
    void DeleteAdmin(int id);
}
