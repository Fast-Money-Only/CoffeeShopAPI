using Business.Service.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Model;


namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CakeController : Controller
{
    private readonly ICakeService _cakeService;
    private readonly ILogger<AddressController> _logger;

    public CakeController(ICakeService cakeService, ILogger<AddressController> logger)
    {
        _cakeService = cakeService;
        _logger = logger;
    }
    
    [HttpGet]
    [Route("GetCakes")]
    public IActionResult GetCakes()
    {
        var cakes = _cakeService.GetCakes();
        _logger.Log(LogLevel.Information, "GetCakes called, returning {0} cakes", cakes.Count);
        return Ok(cakes);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCake(Guid id)
    {
        var cake = _cakeService.GetCake(id);
        _logger.Log(LogLevel.Information, "GetCake called with id {0}", id);

        if (cake == null)
        {
            _logger.Log(LogLevel.Information, "GetCake called with id {0}, but no cake with that id exists", id);
            return NotFound();
        }
        return Ok(cake);
    }
    
    [HttpPost]
    public IActionResult CreateCake([FromBody] Cake cake)
    {
        try
        {
            var newCake = _cakeService.CreateCake(cake);
            _logger.Log(LogLevel.Information, "CreateCake called");
            return CreatedAtAction(nameof(GetCake), new { id = newCake.Id }, newCake);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _logger.Log(LogLevel.Information, "CreateCake called, but no cake was created");
            throw;
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteCake(Guid id)
    {
        try
        {
            _logger.Log(LogLevel.Information, "DeleteCake called with id {0}", id);
            _cakeService.DeleteCake(id);
            return NoContent();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Information, "UpdateCake called with id {0}, but no cake with that id exists", id);
            return NotFound();
        }
    }
}