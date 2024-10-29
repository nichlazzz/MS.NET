using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restoraunt.Restoraunt.BL.Auth;
using Restoraunt.Restoraunt.Service.Controllers.Entities;

namespace Restoraunt.Restoraunt.Service.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserProvider _usersProvider;
    private readonly IUsersManager _usersManager;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public UsersController(IUserProvider usersProvider, IUsersManager usersManager, IMapper mapper,
        ILogger<UsersController> logger)
    {
        _usersManager = usersManager;
        _usersProvider = usersProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet] //users/
    public IActionResult GetAllUsers()
    {
        var users = _usersProvider.GetUsers();
        return Ok(users.ToList());
    }

    [HttpGet]
    [Route("{id}")] //users/{id}
    public IActionResult GetUserInfo([FromRoute] int id)
    {
        try
        {
            var user = _usersProvider.GetUserInfo(id);
            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Error occurred while getting user info.");
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserRequest request)
    {
        try
        {
            var user = _usersManager.CreateUser(request);
            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Error occurred while creating user.");
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateUserInfo([FromRoute] int id, UpdateUserRequest request)
    {
        try
        {
            var user = _usersManager.UpdateUser(id, request);
            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Error occurred while updating user info.");
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteUser([FromRoute] int id)
    {
        try
        {
            _usersManager.DeleteUser(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Error occurred while deleting user.");
            return NotFound(ex.Message);
        }
    }
}