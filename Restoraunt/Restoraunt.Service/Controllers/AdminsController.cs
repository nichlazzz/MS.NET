using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restoraunt.Restoraunt.BL.Auth;
using Restoraunt.Restoraunt.BL.Auth.Entities;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.Service.Controllers;
[Authorize]
[ApiController]
[Route("[controller]")]
public class AdminsController : ControllerBase
{
    private readonly IAdminsProvider _adminsProvider;
    private readonly IAdminsManager _adminsManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public AdminsController(IAdminsProvider adminsProvider, IAdminsManager adminsManager, IMapper mapper,
        ILogger logger)
    {
        _adminsManager = adminsManager;
        _adminsProvider = adminsProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet] //admins/
    public IActionResult GetAllAdmins()
    {
        var admins = _adminsProvider.GetAdmins();
        return Ok(new AdminsListResponse()
        {
            Admins = admins.ToList()
        });
    }
    [HttpGet]
    [Route("filter")] //admins/filter?filter.email=admin@example.com
    public IActionResult GetFilteredAdmins([FromQuery] AdminModelFilter filter)
    {
        var admins = _adminsProvider.GetAdmins(_mapper.Map<AdminModelFilter>(filter));
        return Ok(new AdminsListResponse()
        {
            Admins = admins.ToList()
        });
    }

    [HttpGet]
    [Route("{id}")] //admins/{id}
    public IActionResult GetAdminInfo([FromRoute] int id)
    {
        try
        {
            var admin = _adminsProvider.GetAdminInfo(id);
            return Ok(admin);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateAdmin([FromBody] CreateAdminRequest request)
    {
        try
        {
            var admin = _adminsManager.CreateAdmin(_mapper.Map<CreateAdminRequest>(request));
            return Ok(admin);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateAdminInfo([FromRoute] int id, UpdateAdminRequest request)
    {
        try
        {
            var admin = _adminsManager.UpdateAdmin(id, _mapper.Map<UpdateAdminModel>(request));
            return Ok(admin);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteAdmin([FromRoute] int id)
    {
        try
        {
            _adminsManager.DeleteAdmin(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex.ToString());
            return NotFound(ex.Message);
        }
    }
}