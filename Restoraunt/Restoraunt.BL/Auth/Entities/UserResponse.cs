namespace Restoraunt.Restoraunt.BL.Auth.Entities;


public class UsersModelFilter
{
    public string Email { get; set; }
}
public class UpdateUserModel
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}