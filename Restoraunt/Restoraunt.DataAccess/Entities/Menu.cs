using System.ComponentModel.DataAnnotations.Schema;
namespace Restoraunt.Restoraunt.DataAccess;
[Table("menus")]
public class Menu: BaseEntity
{
    public int IdMenu { get; set; }
    public Menu _Menu { get; set; }
    public int IdDish { get; set; }
    public Dish _Dish { get; set; }
    public int IdAdmin { get; set; }
}