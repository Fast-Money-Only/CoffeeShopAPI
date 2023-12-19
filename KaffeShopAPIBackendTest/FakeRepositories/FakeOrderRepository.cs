using _Data;
using _Data.Repository;
using Business.Service.Interfaces;
using Model;

namespace KaffeShopAPIBackendTest.FakeRepositories;

public class FakeOrderRepository : IOrderRepository
{
    private readonly CoffeeShopContext _context;

    public FakeOrderRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public IList<Order> GetAllOrders()
    {
        return _context.Orders.ToList();
    }

    public bool IsDone(Guid id)
    {
        return _context.Orders.Any(x => x.Id == id);
    }

    public Order CreateOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
        return order;
    }

    public IList<Order> GetUserOrders(Guid id)
    {
        IList<Order> orders = _context.Orders.ToList();
        IList<Order> userOrders = new List<Order>();

        foreach (var order in orders)
        {
            if (order.UserId == id)
            {
                userOrders.Add(order);
            }
        }

        return userOrders;
    }

    public OrderProduct CreateOrderProduct(OrderProduct orderProduct)
    {
        _context.OrderProducts.Add(orderProduct);
        _context.SaveChanges();
        return orderProduct;
    }

    public IList<OrderProduct> GetOrderProducts(Guid id)
    {
        IList<OrderProduct> orderProducts = _context.OrderProducts.ToList();
        IList<OrderProduct> userOrderProducts = new List<OrderProduct>();

        foreach (var orderProduct in orderProducts)
        {
            if (orderProduct.OrderId == id)
            {
                userOrderProducts.Add(orderProduct);
            }
        }

        return userOrderProducts;
    }

    public Order? GetOrder(Guid id)
    {
        return _context.Orders.Find(id);
    }

    public IList<Order> GetPending()
    {
        IList<Order> orders = _context.Orders.ToList();
        IList<Order> pendingOrders = new List<Order>();

        foreach (var order in orders)
        {
            if (!order.IsDone)
            {
                pendingOrders.Add(order);
            }
        }
        return pendingOrders;
    }

    public IList<Order> GetDone()
    {
        IList<Order> orders = _context.Orders.ToList();
        IList<Order> doneOrders = new List<Order>();

        foreach (var order in orders)
        {
            if (order.IsDone)
            {
                doneOrders.Add(order);
            }
        }
        return doneOrders;
    }

    public Order UpdateOrder(Guid id, Order order)
    {
        var orderToUpdate = GetOrder(id);
        orderToUpdate!.IsDone = order.IsDone;
        _context.SaveChanges();
        return orderToUpdate;
    }
}