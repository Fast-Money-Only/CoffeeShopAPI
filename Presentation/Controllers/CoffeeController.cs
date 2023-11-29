using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoffeeController : Controller
{
    private readonly ICoffeeService _coffeeService;
    private readonly ILogger<AddressController> _logger;

    public CoffeeController(ICoffeeService coffeeService, ILogger<AddressController> logger)
    {
        _coffeeService = coffeeService;
        _logger = logger;
    }
    
    [HttpGet]
    [Route("GetCoffees")]
    public IActionResult GetCoffees()
    {
        var coffees = _coffeeService.GetCoffees();
        _logger.Log(LogLevel.Information, "GetCoffees called, returning {0} coffees", coffees.Count);
        return Ok(coffees);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCoffee(Guid id)
    {
        var coffee = _coffeeService.GetCoffee(id);
        _logger.Log(LogLevel.Information, "GetCoffee called with id {0}", id);

        if (coffee == null)
        {
            _logger.Log(LogLevel.Information, "GetCoffee called with id {0}, but no coffee with that id exists", id);
            return NotFound();
        }
        return Ok(coffee);
    }
    
    [HttpPost]
    public IActionResult CreateCoffee([FromBody] Coffee coffee)
    {
        try
        {
            var newCoffee = _coffeeService.CreateCoffee(coffee);
            _logger.Log(LogLevel.Information, "CreateCoffee called");
            return CreatedAtAction(nameof(GetCoffee), new { id = newCoffee.Id }, newCoffee);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _logger.Log(LogLevel.Information, "CreateCoffee called, but no coffee was created");
            throw;
        }
    }
    
    [HttpGet]
    [Route("CoffeeIngredients/{id}")]
    public IActionResult CoffeeIngredients(Guid id)
    {
        var ingredients = _coffeeService.CoffeeIngredients(id);
        _logger.Log(LogLevel.Information, "CoffeeIngredients called, returning {0} coffee ingredients", ingredients.Count);
        return Ok(ingredients);
    }
    
    [HttpPost]
    [Route("CoffeeIngredients/Add")]
    public IActionResult CreateCoffeeIngredient([FromBody] CoffeeIngredient coffeeIngredient)
    {
        try
        {
            var newCoffeeIngredient = _coffeeService.CreateCoffeeIngredient(coffeeIngredient);
            _logger.Log(LogLevel.Information, "CreateCoffeeIngredient called");
            return CreatedAtAction(nameof(GetCoffee), new { id = newCoffeeIngredient.Id }, newCoffeeIngredient);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _logger.Log(LogLevel.Information, "CreateCoffeeIngredient called, but no coffeeIngredient was created");
            throw;
        }
    }
    
    [HttpPost]
    [Route("CoffeeCake/Add")]
    public IActionResult CreateCoffeeCake([FromBody] CoffeeCake coffeeCake)
    {
        try
        {
            var newCoffeeCake = _coffeeService.CreateCoffeeCake(coffeeCake);
            _logger.Log(LogLevel.Information, "CreateCoffeeIngredient called");
            return CreatedAtAction(nameof(GetCoffee), new { id = newCoffeeCake.Id }, newCoffeeCake);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _logger.Log(LogLevel.Information, "CreateCoffeeIngredient called, but no coffeeIngredient was created");
            throw;
        }
    }
    
    
    [HttpGet]
    [Route("CoffeeCake/{id}")]
    public IActionResult CoffeeCake(Guid id)
    {
        var cakes = _coffeeService.CoffeeCake(id);
        _logger.Log(LogLevel.Information, "CoffeeCake called, returning {0} cakes", cakes.Count);
        return Ok(cakes);
    }
}