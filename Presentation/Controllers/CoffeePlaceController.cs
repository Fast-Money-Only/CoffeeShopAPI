using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoffeePlaceController : Controller
{
    private readonly ICoffeePlaceService _coffeePlaceService;
    private readonly ILogger<AddressController> _logger;

    public CoffeePlaceController(ICoffeePlaceService coffeePlaceService, ILogger<AddressController> logger)
    {
        _coffeePlaceService = coffeePlaceService;
        _logger = logger;
    }
    
    [HttpGet]
    [Route("GetCoffeePlaces")]
    public IActionResult GetCoffeePlaces()
    {
        var coffeePlaces = _coffeePlaceService.GetCoffeePlaces();
        _logger.Log(LogLevel.Information, "GetCoffeePlaces called, returning {0} places", coffeePlaces.Count);
        return Ok(coffeePlaces);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCoffeePlace(Guid id)
    {
        var coffeePlace = _coffeePlaceService.GetCoffeePlace(id);
        _logger.Log(LogLevel.Information, "GetCoffeePlace called with id {0}", id);

        if (coffeePlace == null)
        {
            _logger.Log(LogLevel.Information, "GetCoffeePlace called with id {0}, but no coffee place with that id exists", id);
            return NotFound();
        }
        return Ok(coffeePlace);
    }
}