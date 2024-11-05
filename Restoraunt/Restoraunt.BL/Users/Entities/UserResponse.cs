namespace Restoraunt.Restoraunt.BL.Auth.Entities;


public class UserModelFilter
{
    public string Email { get; set; }
}
public class UpdateUserModel
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
