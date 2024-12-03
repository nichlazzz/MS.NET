namespace Restoraunt.Restoraunt.BL.Orders.Entities;

public class OrdersFilter
{
    public int? IdUser { get; set; }

    public DateTime? DateCreateFrom { get; set; }

    public DateTime? DateCreateTo { get; set; }
}