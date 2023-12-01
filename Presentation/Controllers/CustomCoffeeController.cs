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
    
    [HttpPost("CreateCustomCoffeeIngredient")]
    public IActionResult CreateCustomCoffeeIngredient([FromBody] CCoffeIngredient cCoffeIngredient)
    {
        try
        {
            var newCustomCoffeeIngredient = _customCoffeeService.CreateCustomCoffeeIngredient(cCoffeIngredient);
            return CreatedAtAction(nameof(GetCustomCoffee), new { id = newCustomCoffeeIngredient.CustomCoffeeId }, newCustomCoffeeIngredient);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("GetCustomCoffeeIngredient/{id}")]
    public IActionResult GetCustomCoffeeIngredient(Guid id)
    {
        var customIngredients = _customCoffeeService.CustomCoffeeIngredients(id);
       
        return Ok(customIngredients);
    }
    
}