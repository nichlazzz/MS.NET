namespace Restoraunt.Restoraunt.BL.Dishes.Entities;

public class CreateDishModel
{
    public Guid ExternalId { get; set; }
    public decimal Cost { get; set; }
    public string Category { get; set; }
    public object Image { get; set; }
}
