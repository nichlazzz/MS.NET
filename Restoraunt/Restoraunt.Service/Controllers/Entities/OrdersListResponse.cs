using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.Service.Controllers.Entities;


public class OrdersListResponse
{
    public List<OrderModel> Orders { get; set; }
}
