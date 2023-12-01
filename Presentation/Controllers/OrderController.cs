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
        try
        {
            var newOrder = _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.Id }, newOrder);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("GetUserOrders/{id}")]
    public IActionResult GetUserOrders(Guid id)
    {
        var orders = _orderService.GetUserOrders(id);
        return Ok(orders);
    }
    
    [HttpGet("GetOrderProducts")]
    public IActionResult GetOrderProducts(Guid id)
    {
        var orderProducts = _orderService.GetOrderProducts();
        return Ok(orderProducts);
    }
    
    [HttpPost("OrderProducts")]
    public IActionResult CreateOrderProduct([FromBody] OrderProduct orderProduct)
    {
        try
        {
            var newOrderProduct = _orderService.CreateOrderProduct(orderProduct);
            return CreatedAtAction(nameof(GetOrder), new { id = newOrderProduct.Id }, newOrderProduct);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}