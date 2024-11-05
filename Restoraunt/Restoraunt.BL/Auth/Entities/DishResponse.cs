namespace Restoraunt.Restoraunt.BL.Auth.Entities;


public class DishesModelFilter
{
    public string Category { get; set; }
    public decimal? MinCost { get; set; }
    public decimal? MaxCost { get; set; }
}
public class UpdateDishModel
{
    public string Category { get; set; }
    public decimal Cost { get; set; }
    public object Image { get; set; }
}