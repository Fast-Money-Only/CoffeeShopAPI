using Model;

namespace Business.Service.Interfaces;

public interface IOrderService
{
    IList<Order> GetAllOrders();
    bool IsDone(Guid id);
    Order CreateOrder(Order order);
}