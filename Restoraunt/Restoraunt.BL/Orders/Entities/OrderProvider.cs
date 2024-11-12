using AutoMapper;
using Restoraunt.Restoraunt.BL.Orders;
using Restoraunt.Restoraunt.DataAccess;

namespace Restoraunt.DataAccess.Migrations.Restoraunt.BL.Orders.Entities;

public class OrderProvider : IOrderProvider
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IMapper _mapper;

    public OrderProvider(IRepository<Order> orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public IEnumerable<OrderModel> GetOrders()
    {
        var orders = _orderRepository.GetAll();
        return _mapper.Map<IEnumerable<OrderModel>>(orders);
    }

    public OrderModel GetOrderInfo(int id)
    {
        var order = _orderRepository.GetById(id);
        if (order == null)
        {
            throw new ArgumentException("Order not found.");
        }

        return _mapper.Map<OrderModel>(order);
    }

    public IEnumerable<OrderModel> GetOrders(OrderModelFilter filter)
    {
        var orders = _orderRepository.GetAll(); // Assuming GetByFilter is not implemented
        return _mapper.Map<IEnumerable<OrderModel>>(orders);
    }
}
