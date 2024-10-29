using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restoraunt.Restoraunt.BL.Auth;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.Service.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class DishesController : ControllerBase
{
    private readonly IDishesProvider _dishesProvider;
    private readonly IDishesManager _dishesManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public DishesController(IDishesProvider dishesProvider, IDishesManager dishesManager, IMapper mapper,
        ILogger logger)
    {
        _dishesManager = dishesManager;
        _dishesProvider = dishesProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet] //dishes/
    public IActionResult GetAllDishes()
    {
        var dishes = _dishesProvider.GetDishes();
        return Ok(new DishesListResponse()
        {
            Dishes = dishes.ToList()
        });
    }

    [HttpGet]
    [Route("filter")] //dishes/filter?filter.category=Pizza
    public IActionResult GetFilteredDishes([FromQuery] DishesFilter filter)
    {
        var dishes = _dishesProvider.GetDishes(_mapper.Map<DishesFilter>(filter));
        return Ok(new DishesListResponse()
        {
            Dishes = dishes.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")] //dishes/{id}
    public IActionResult GetDishInfo([FromRoute] int id)
    {
        try
        {
            var dish = _dishesProvider.GetDishInfo(id);
            return Ok(dish);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateDish([FromBody] CreateDishRequest request)
    {
        try
        {
            var dish = _dishesManager.CreateDish(_mapper.Map<CreateDishRequest>(request));
            return Ok(dish);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateDishInfo([FromRoute] int id, UpdateDishRequest request)
    {
        try
        {
            var dish = _dishesManager.UpdateDish(id, _mapper.Map<UpdateDishRequest>(request));
            return Ok(dish);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteDish([FromRoute] int id)
    {
        try
        {
            _dishesManager.DeleteDish(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }
}