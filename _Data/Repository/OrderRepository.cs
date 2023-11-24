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
}