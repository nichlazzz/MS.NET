using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Reflection;

namespace Restoraunt.Restoraunt.DataAccess;
[Table("dishes")]
public class Dish: BaseEntity
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; } 
    public SqlMoney Cost { get; set; }
    public string Category { get; set; }
    public Object Image { get; set; }
    
    // public int IdOrder { get; set; }
    public ICollection<Order> Orders { get; set; }
    // public int IdMenu { get; set; }
    public ICollection<Menu> Menus { get; set; }
}