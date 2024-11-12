using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;

namespace Restoraunt.Restoraunt.BL.Orders;

public interface IOrderManager
{
    // Create a new order
    OrderModel CreateOrder(CreateOrderModel model);

    // Update an existing order
    OrderModel UpdateOrder(int id, UpdateOrderModel model);

    // Delete an order
    void DeleteOrder(int id);
}

