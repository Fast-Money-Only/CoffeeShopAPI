using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpGet]
    [Route("GetOrders")]
    public IActionResult GetOrders()
    {
        var orders = _orderService.GetAllOrders();
        return Ok(orders);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetOrder(Guid id)
    {
        var order = _orderService.GetOrder(id);
        return Ok(order);
    }
    

    [HttpPost]
    public IActionResult CreateOrder([FromBody] Order order)
    {
        var newOrder = _orderService.CreateOrder(order);
        return CreatedAtAction(nameof(GetOrder), new { id = newOrder.Id }, newOrder);
    }
    
    [HttpGet("Get user orders {id}")]
    public IActionResult GetUserOrders(Guid id)
    {
        var orders = _orderService.GetUserOrders(id);
        return Ok(orders);
    }
}