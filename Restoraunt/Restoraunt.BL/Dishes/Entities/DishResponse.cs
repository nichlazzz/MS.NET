namespace Restoraunt.Restoraunt.BL.Dishes.Entities;

public class UpdateDishModel
{
    public Guid ExternalId { get; set; }
    public decimal Cost { get; set; }
    public string Category { get; set; }
    public object Image { get; set; }
}

public class DishModelFilter
{
    public Guid? ExternalId { get; set; }
    public string Category { get; set; }
    // ... other filter properties
}
