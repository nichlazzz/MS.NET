using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IUsersManager
{
    // Create a new user
    User CreateUser(CreateUserRequest request); // Assuming you're using CreateUserRequest from your service

    // Update an existing user
    User UpdateUser(int id, UpdateUserRequest request); // Assuming you're using UpdateUserRequest from your service

    // Delete a user
    void DeleteUser(int id);
}