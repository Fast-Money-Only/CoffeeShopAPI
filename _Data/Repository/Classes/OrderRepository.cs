using Model;

namespace _Data.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly CoffeeShopContext _context;

    public OrderRepository(CoffeeShopContext context)
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
}