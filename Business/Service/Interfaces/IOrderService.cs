using Model;

namespace Business.Service.Interfaces;

public interface IOrderService
{
    IList<Order> GetAllOrders();
    bool IsDone(Guid id);
    Order CreateOrder(Order order);

    OrderProduct CreateOrderProduct(OrderProduct orderProduct);

    IList<OrderProduct> GetOrderProducts(Guid id);

    IList<Order> GetUserOrders(Guid id);

    Order GetOrder(Guid id);
}