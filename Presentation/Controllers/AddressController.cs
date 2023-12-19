using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : Controller
{
    private readonly IAddressService _addressService;
    private readonly ILogger<AddressController> _logger;

    public AddressController(IAddressService addressService, ILogger<AddressController> logger)
    {
        _addressService = addressService;
        _logger = logger;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetAddress(Guid id)
    {
        var address = _addressService.GetAddress(id);
        _logger.Log(LogLevel.Information, "GetAddress called with id {0}", id);

        if (address == null)
        {
            _logger.Log(LogLevel.Information, "GetAddress called with id {0}, but no address with that id exists", id);
            return NotFound();
        }
        return Ok(address);
    }
    
    [HttpPost]
    public IActionResult CreateAddress([FromBody] Address address)
    {
        try
        {
            var newAddress = _addressService.CreateAddress(address);
            _logger.Log(LogLevel.Information, "CreateAddress called");
            return CreatedAtAction(nameof(GetAddress), new { id = newAddress.AddressID }, newAddress);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _logger.Log(LogLevel.Information, "CreateAddress called, but no address was created");
            throw;
        }
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateAddress(Guid id, [FromBody] Address address)
    {
        try
        {
            _logger.Log(LogLevel.Information, "UpdateAddress called with id {0}", id);
            var updatedBook = _addressService.UpdateAddress(id, address);
            return Ok(updatedBook);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Information, "UpdateAddress called with id {0}, but no address with that id exists", id);
            return NotFound();
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(Guid id)
    {
        try
        {
            _logger.Log(LogLevel.Information, "DeleteAddress called with id {0}", id);
            _addressService.DeleteAddress(id);
            return NoContent();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Information, "UpdateAddress called with id {0}, but no address with that id exists", id);
            return NotFound();
        }
    }
    
}