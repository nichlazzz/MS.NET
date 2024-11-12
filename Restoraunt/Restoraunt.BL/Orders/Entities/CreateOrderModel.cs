namespace Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;

public class CreateOrderModel
{
    public string Heading { get; set; }
    public string Details { get; set; }
    public int IdDish { get; set; }
    public int IdUser { get; set; }
}
