using AutoMapper;
using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    
    public UserController(IUserService userService,  IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [Route("GetUsers")]
    public IActionResult GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(Guid id)
    {
        var user = _userService.GetUser(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserDTO createUserDto)
    {
        var user = new User();
        _mapper.Map(createUserDto, user);
        var newUser = _userService.CreateUser(user);
        return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, [FromBody] User user)
    {
        try
        {
            var updatedUser = _userService.UpdateUser(id, user);
            return Ok(updatedUser);
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        try
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }
    
    [HttpGet("GetUserOrders/{id}")]
    public IActionResult GetUserOrders(Guid id)
    {
        var userOrders = _userService.GetUserOrders(id);
        return Ok(userOrders);
    }
    
    [HttpGet("LoginUser/{email}/{password}")]
    public IActionResult LoginUser(string email, string password)
    {
        if (email == null || password == null)
        {
            return BadRequest();
        }

        var LoggedUser = _userService.LoginUser(email, password);
        if (LoggedUser == null)
        {
            return NotFound(LoggedUser);
        }


        return Ok(LoggedUser);
    }
}