using Model;

namespace _Data.Repository;

public class OrderRepository : IOrderRepository
{
    public IList<Order> GetAllOrders()
    {
        return null;
    }

    public bool IsDone(Guid id)
    {
        throw new NotImplementedException();
    }

    public Order CreatOrder(Order order)
    {
        throw new NotImplementedException();
    }
}