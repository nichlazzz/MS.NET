namespace Restoraunt.Restoraunt.BL.Auth.Entities;

public class OrdersModelFilter
{
    public int? IdUser { get; set; }
    public DateTime? DateCreateFrom { get; set; }
    public DateTime? DateCreateTo { get; set; }
}
public class UpdateOrderModel
{
    public string Heading { get; set; }
    public DateTime DateCreate { get; set; }
    public string Details { get; set; }
    public List<int> DishIds { get; set; }
}