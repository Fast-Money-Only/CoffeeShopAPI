using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CustomCoffeeController : Controller
{
    private readonly ICustomCoffeeService _customCoffeeService;
    private readonly ILogger<AddressController> _logger;
    
    public CustomCoffeeController(ICustomCoffeeService customCoffeeService)
    {
        _customCoffeeService = customCoffeeService;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCustomCoffee(Guid id)
    {
        var customCoffee = _customCoffeeService.GetCustomCoffee(id);

        if (customCoffee == null)
        {
            _logger.Log(LogLevel.Information, "GetAddress called with id {0}, but no address with that id exists", id);
            return NotFound();
        }
        return Ok(customCoffee);
    }
    
    [HttpPost]
    public IActionResult CreateCustomCoffee([FromBody] CustomCoffee customCoffee)
    {
        try
        {
            var newCustomCoffee = _customCoffeeService.CreateCustomCoffee(customCoffee);
            _logger.Log(LogLevel.Information, "CreateAddress called");
            return CreatedAtAction(nameof(GetCustomCoffee), new { id = newCustomCoffee.CustomCoffeeId }, newCustomCoffee);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _logger.Log(LogLevel.Information, "CreateAddress called, but no address was created");
            throw;
        }
    }
}