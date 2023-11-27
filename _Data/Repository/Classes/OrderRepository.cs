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
        IList<Order> userOrders = null;

        foreach (var order in orders)
        {
            if (order.UserId == id)
            {
                userOrders.Add(order);
            }
        }

        return userOrders;
    }

    public Order? GetOrder(Guid id)
    {
        return _context.Orders.Find(id);
    }
}