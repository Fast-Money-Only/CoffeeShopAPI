using Model;

namespace _Data.Repository;

public interface IOrderRepository
{
    IList<Order> GetAllOrders();
    bool IsDone(Guid id);
    Order CreateOrder(Order order);
    IList<Order> GetUserOrders(Guid id);
    
    OrderProduct CreateOrderProduct(OrderProduct orderProduct);

    IList<OrderProduct> GetOrderProducts();
    
    Order? GetOrder(Guid id);
}