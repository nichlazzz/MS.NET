using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restoraunt.DataAccess.Migrations.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.BL.Auth;
using Restoraunt.Restoraunt.BL.FavoriteDishes.Entities;
using Restoraunt.Restoraunt.Service.Controllers.Entities;
using FavoriteDishesFilter = Restoraunt.Restoraunt.BL.FavoriteDishes.Entities.FavoriteDishesFilter;

namespace Restoraunt.Restoraunt.Service.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class FavoriteDishesController : ControllerBase
{
    private readonly Restoraunt.BL.FavoriteDishes.IFavoriteDishProvider _favoriteDishesProvider;
    private readonly Restoraunt.BL.FavoriteDishes.IFavoriteDishManager _favoriteDishesManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public FavoriteDishesController(Restoraunt.BL.FavoriteDishes.FavoriteDishProvider favoriteDishesProvider, Restoraunt.BL.FavoriteDishes.IFavoriteDishManager favoriteDishesManager, IMapper mapper,
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
        var favoriteDishes = _favoriteDishesProvider.GetFavoriteDishes(_mapper.Map<FavoriteDishModelFilter>(filter));
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
            var favoriteDish = _favoriteDishesManager.CreateFavoriteDish(_mapper.Map<CreateFavoriteDishModel>(request));
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
            var favoriteDish = _favoriteDishesManager.UpdateFavoriteDish(id, _mapper.Map<UpdateFavoriteDishModel>(request));
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