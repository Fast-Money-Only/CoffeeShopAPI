using System.Collections;
using _Data.Repository;
using AutoMapper;
using Business.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IProductService productService, IMapper mapper)
    {
        _orderService = orderService;
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [Route("GetOrders")]
    public IActionResult GetOrders()
    {
        var orders = _orderService.GetAllOrders();
        return Ok(orders);
    }
    
    [HttpGet]
    [Route("GetPending")]
    public IActionResult GetPending()
    {
        var orders = _orderService.GetPending();
        return Ok(orders);
    }
    
    [HttpGet]
    [Route("GetDone")]
    public IActionResult GetDone()
    {
        var orders = _orderService.GetDone();
        return Ok(orders);
    }
   
    
    [HttpGet("{id}")]
    public IActionResult GetOrder(Guid id)
    {
        var order = _orderService.GetOrder(id);
        return Ok(order);
    }
    

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderDTO createOrderDto)
    {
        try
        {
            var order = new Order();
            _mapper.Map(createOrderDto, order);
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
    
    [HttpGet("GetOrderProducts/{id}")]
    public IActionResult GetOrderProducts(Guid id)
    {
        var orderProducts = _orderService.GetOrderProducts(id);
        IList<GetOrderProductDTO> products = new List<GetOrderProductDTO>();
        foreach (var oProduct in orderProducts)
        {
            var product = _productService.GetProduct(oProduct.ProductId);
            var productDto = new GetOrderProductDTO();
            productDto.Id = oProduct.Id;
            productDto.Name = product.ProductName;
            productDto.Quantity = oProduct.Quantity;
            productDto.Price = product.Price * oProduct.Quantity;
            
            products.Add(productDto);
        }
        return Ok(products);
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
    
    [HttpPut("{id}")]
    public IActionResult UpdateOrder(Guid id, [FromBody] CreateOrderDTO orderDto)
    {
        
        try
        {
            var order = _orderService.GetOrder(id);
            _mapper.Map(orderDto, order);
            var updatedOrder = _orderService.UpdateOrder(id, order);
            return Ok(updatedOrder);
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }
}