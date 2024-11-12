using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;

namespace Restoraunt.Restoraunt.BL.Orders;

public interface IOrderProvider
{
    // Get all orders
    IEnumerable<OrderModel> GetOrders();

    // Get a specific order by Id
    OrderModel GetOrderInfo(int id);

    // Get filtered orders
    IEnumerable<OrderModel> GetOrders(OrderModelFilter filter);
}

