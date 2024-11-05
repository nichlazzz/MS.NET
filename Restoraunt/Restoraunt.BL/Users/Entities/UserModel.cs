namespace Restoraunt.Restoraunt.BL.Auth.Entities;

public class UserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    // Add other properties as needed (e.g., Email, etc.)
    public ICollection<OrderModel> Orders { get; set; }
    public ICollection<FavoriteDishModel> FavoriteDishes { get; set; }
}