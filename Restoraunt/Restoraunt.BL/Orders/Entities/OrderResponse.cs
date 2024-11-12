namespace Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;

public class UpdateOrderModel
{
    public string Heading { get; set; }
    public string Details { get; set; }
    public int IdDish { get; set; }
    public int IdUser { get; set; }
}

public class OrderModelFilter
{
    public int? IdDish { get; set; }
    public DateTime? DateCreateFrom { get; set; }
    public DateTime? DateCreateTo { get; set; }
    // ... other filter properties
}
