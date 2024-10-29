using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restoraunt.Restoraunt.BL.Auth;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.Service.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class FavoriteDishesController : ControllerBase
{
    private readonly IFavoriteDishesProvider _favoriteDishesProvider;
    private readonly IFavoriteDishesManager _favoriteDishesManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public FavoriteDishesController(IFavoriteDishesProvider favoriteDishesProvider, IFavoriteDishesManager favoriteDishesManager, IMapper mapper,
        ILogger logger)
    {
        _favoriteDishesManager = favoriteDishesManager;
        _favoriteDishesProvider = favoriteDishesProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet] //favorite-dishes/
    public IActionResult GetAllFavoriteDishes()
    {
        var favoriteDishes = _favoriteDishesProvider.GetFavoriteDishes();
        return Ok(new FavoriteDishesListResponse()
        {
            FavoriteDishes = favoriteDishes.ToList()
        });
    }

    [HttpGet]
    [Route("filter")] //favorite-dishes/filter?filter.idUser=1
    public IActionResult GetFilteredFavoriteDishes([FromQuery] FavoriteDishesFilter filter)
    {
        var favoriteDishes = _favoriteDishesProvider.GetFavoriteDishes(_mapper.Map<FavoriteDishesFilter>(filter));
        return Ok(new FavoriteDishesListResponse()
        {
            FavoriteDishes = favoriteDishes.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")] //favorite-dishes/{id}
    public IActionResult GetFavoriteDishInfo([FromRoute] int id)
    {
        try
        {
            var favoriteDish = _favoriteDishesProvider.GetFavoriteDishInfo(id);
            return Ok(favoriteDish);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateFavoriteDish([FromBody] CreateFavoriteDishRequest request)
    {
        try
        {
            var favoriteDish = _favoriteDishesManager.CreateFavoriteDish(_mapper.Map<CreateFavoriteDishRequest>(request));
            return Ok(favoriteDish);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateFavoriteDishInfo([FromRoute] int id, UpdateFavoriteDishRequest request)
    {
        try
        {
            var favoriteDish = _favoriteDishesManager.UpdateFavoriteDish(id, _mapper.Map<UpdateFavoriteDishRequest>(request));
            return Ok(favoriteDish);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteFavoriteDish([FromRoute] int id)
    {
        try
        {
            _favoriteDishesManager.DeleteFavoriteDish(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }
}