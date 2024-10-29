using System.ComponentModel.DataAnnotations.Schema;

namespace Restoraunt.Restoraunt.DataAccess;
[Table("favorite-dishes")]
public class FavoriteDish: Dish
{
    public string Descroption { get; set; }
    public int IdUser { get; set; }
    public User _User { get; set; }
}
