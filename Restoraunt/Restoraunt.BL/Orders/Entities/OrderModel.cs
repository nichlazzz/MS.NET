
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.BL.Dishes.Entities;

namespace Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;


public class OrderModel
{
    public int Id { get; set; }
    public ICollection<DishModel> Dishes { get; set; }
    public string Heading { get; set; }
    public DateTime DateCreate { get; set; }
    public string Details { get; set; }

    public int IdDish { get; set; }
    public DishModel _Dish { get; set; }
    public int IdUser { get; set; }
    public UserModel _User { get; set; }
}



