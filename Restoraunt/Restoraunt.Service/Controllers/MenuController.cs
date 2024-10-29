using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restoraunt.Restoraunt.BL.Auth;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.Service.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class MenusController : ControllerBase
{
    private readonly IMenusProvider _menusProvider;
    private readonly IMenusManager _menusManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public MenusController(IMenusProvider menusProvider, IMenusManager menusManager, IMapper mapper,
        ILogger logger)
    {
        _menusManager = menusManager;
        _menusProvider = menusProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet] //menus/
    public IActionResult GetAllMenus()
    {
        var menus = _menusProvider.GetMenus();
        return Ok(new MenusListResponse()
        {
            Menus = menus.ToList()
        });
    }

    [HttpGet]
    [Route("filter")] //menus/filter?filter.idAdmin=1
    public IActionResult GetFilteredMenus([FromQuery] MenusFilter filter)
    {
        var menus = _menusProvider.GetMenus(_mapper.Map<MenusFilter>(filter));
        return Ok(new MenusListResponse()
        {
            Menus = menus.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")] //menus/{id}
    public IActionResult GetMenuInfo([FromRoute] int id)
    {
        try
        {
            var menu = _menusProvider.GetMenuInfo(id);
            return Ok(menu);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateMenu([FromBody] CreateMenuRequest request)
    {
        try
        {
            var menu = _menusManager.CreateMenu(_mapper.Map<CreateMenuRequest>(request));
            return Ok(menu);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateMenuInfo([FromRoute] int id, UpdateMenuRequest request)
    {
        try
        {
            var menu = _menusManager.UpdateMenu(id, _mapper.Map<UpdateMenuRequest>(request));
            return Ok(menu);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteMenu([FromRoute] int id)
    {
        try
        {
            _menusManager.DeleteMenu(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }
}