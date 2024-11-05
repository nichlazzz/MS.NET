using Restoraunt.Restoraunt.BL.Auth.Entities;

namespace Restoraunt.Restoraunt.BL.Trainers.Entities;

public class AdminModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    // Add other properties as needed (e.g., Name, Role, etc.)
    public ICollection<MenuModel> Menus { get; set; }
}

