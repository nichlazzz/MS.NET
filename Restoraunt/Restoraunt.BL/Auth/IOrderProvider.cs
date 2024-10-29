using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IOrdersProvider
{
    // Get all orders
    IEnumerable<Order> GetOrders();

    // Get a specific order by Id
    Order GetOrderInfo(int id);

    // Get filtered orders
    IEnumerable<Order> GetOrders(OrdersFilter filter); 
}
