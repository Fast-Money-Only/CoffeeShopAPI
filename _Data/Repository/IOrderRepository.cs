using Model;

namespace _Data.Repository;

public interface IOrderRepository
{
    IList<Order> GetAllOrders();
    bool IsDone(Guid id);
    Order CreatOrder(Order order);
}