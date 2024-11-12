using AutoMapper;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.Restoraunt.BL.Orders;

public class OrderManager : IOrderManager
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IMapper _mapper;

    public OrderManager(IRepository<Order> orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public OrderModel CreateOrder(CreateOrderModel model)
    {
        var entity = _mapper.Map<Order>(model);

        _orderRepository.Save(entity);

        return _mapper.Map<OrderModel>(entity);
    }

    public OrderModel UpdateOrder(int id, UpdateOrderModel model)
    {
        var entity = _orderRepository.GetById(id);
        if (entity == null)
        {
            throw new ArgumentException("Order not found.");
        }

        _mapper.Map(model, entity);

        _orderRepository.Save(entity);

        return _mapper.Map<OrderModel>(entity);
    }

    public void DeleteOrder(int id)
    {
        var entity = _orderRepository.GetById(id);
        if (entity == null)
        {
            throw new ArgumentException("Order not found.");
        }

        _orderRepository.Delete(entity);
    }
}
