using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CustomCoffeeController : Controller
{
    private readonly ICustomCoffeeService _customCoffeeService;
    
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
            return CreatedAtAction(nameof(GetCustomCoffee), new { id = newCustomCoffee.CustomCoffeeId }, newCustomCoffee);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}