using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
namespace Restoraunt.Restoraunt.DataAccess;
[Table("orders")]
public class Order: BaseEntity
{
    public virtual ICollection<Dish> Diches { get; set; }
    public string Heading { get; set; }
    public DateTime DateCreate { get; set; }
    public string Details { get; set; }
    
    public int IdDish { get; set; }
    public Dish _Dish { get; set; }
    public int IdUser { get; set; }
    public User _User { get; set; }
    
}