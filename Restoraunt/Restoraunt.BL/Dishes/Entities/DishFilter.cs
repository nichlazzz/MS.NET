

namespace Restoraunt.Restoraunt.BL.Dishes.Entities;

public class DishesFilter
{
    public string Category { get; set; }

    public decimal? MinCost { get; set; }

    public decimal? MaxCost { get; set; }
}