using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.BL.Trainers.Entities;
using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IAdminsManager
{
    // Create a new admin
    AdminModel CreateAdmin(CreateAdminRequest model);

    // Update an existing admin
    AdminModel UpdateAdmin(int id, UpdateAdminModel model);

    // Delete an admin
    void DeleteAdmin(int id);
}