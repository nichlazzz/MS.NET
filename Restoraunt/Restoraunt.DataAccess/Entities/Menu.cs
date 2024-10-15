namespace Restoraunt.Restoraunt.DataAccess;

public class Menu: BaseEntity
{
    private ICollection<Dish> Dishes { get; set; }  
}