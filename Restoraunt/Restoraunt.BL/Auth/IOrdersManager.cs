using Restoraunt.Restoraunt.DataAccess;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.BL.Auth;

public interface IOrdersManager
{
    // Create a new order
    Order CreateOrder(CreateOrderRequest model);

    // Update an existing order
    Order UpdateOrder(int id, UpdateOrderRequest model);

    // Delete an order
    void DeleteOrder(int id);
}
