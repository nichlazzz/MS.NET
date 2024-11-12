using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;
using Restoraunt.Restoraunt.BL.Auth.Entities;

namespace Restoraunt.Restoraunt.BL.Dishes.Entities;

public class DishModel
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public decimal Cost { get; set; } // Map SqlMoney to decimal
    public string Category { get; set; }
    public object Image { get; set; } // Keep as object, you'll likely have to handle this differently

    public ICollection<OrderModel> Orders { get; set; }
    public ICollection<MenuModel> Menus { get; set; }
}