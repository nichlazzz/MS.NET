using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restoraunt.Restoraunt.BL.Auth;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.Service.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrdersProvider _ordersProvider;
    private readonly IOrdersManager _ordersManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public OrdersController(IOrdersProvider ordersProvider, IOrdersManager ordersManager, IMapper mapper,
        ILogger logger)
    {
        _ordersManager = ordersManager;
        _ordersProvider = ordersProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet] //orders/
    public IActionResult GetAllOrders()
    {
        var orders = _ordersProvider.GetOrders();
        return Ok(new OrdersListResponse()
        {
            Orders = orders.ToList()
        });
    }

    [HttpGet]
    [Route("filter")] //orders/filter?filter.idUser=1&filter.dateCreateFrom=2023-01-01&filter.dateCreateTo=2023-02-01
    public IActionResult GetFilteredOrders([FromQuery] OrdersFilter filter)
    {
        var orders = _ordersProvider.GetOrders(_mapper.Map<OrdersFilter>(filter));
        return Ok(new OrdersListResponse()
        {
            Orders = orders.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")] //orders/{id}
    public IActionResult GetOrderInfo([FromRoute] int id)
    {
        try
        {
            var order = _ordersProvider.GetOrderInfo(id);
            return Ok(order);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
    {
        try
        {
            var order = _ordersManager.CreateOrder(_mapper.Map<CreateOrderRequest>(request));
            return Ok(order);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateOrderInfo([FromRoute] int id, UpdateOrderRequest request)
    {
        try
        {
            var order = _ordersManager.UpdateOrder(id, _mapper.Map<UpdateOrderRequest>(request));
            return Ok(order);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteOrder([FromRoute] int id)
    {
        try
        {
            _ordersManager.DeleteOrder(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }
}