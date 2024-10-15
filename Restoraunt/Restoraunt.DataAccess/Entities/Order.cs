using System.Net.Mime;

namespace Restoraunt.Restoraunt.DataAccess;

public class Order: BaseEntity
{
    public virtual ICollection<Dish> Diches { get; set; }
    public string Heading { get; set; }
    public DateTime DateCreate { get; set; }
    public string Details { get; set; }
}