namespace Restoraunt.Restoraunt.Service.Controllers.Entities;

public class DishesFilter
{
    public string Category { get; set; }

    public decimal? MinCost { get; set; }

    public decimal? MaxCost { get; set; }
}