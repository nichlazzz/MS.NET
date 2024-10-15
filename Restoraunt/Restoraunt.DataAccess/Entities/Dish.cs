using System.Data.SqlTypes;
using System.Reflection;

namespace Restoraunt.Restoraunt.DataAccess;

public class Dish: BaseEntity
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; } 
    public SqlMoney Cost { get; set; }
    public string Category { get; set; }
    public Object Image { get; set; } 
}