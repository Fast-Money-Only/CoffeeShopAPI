using Business.Service.Interfaces;
using Model;

namespace _Data.Repository;

public class OrderService : IOrderService
{
    private IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public IList<Order> GetAllOrders()
    {
        return _orderRepository.GetAllOrders();
    }

    public bool IsDone(Guid id)
    {
        return _orderRepository.IsDone(id);
    }

    public Order CreateOrder(Order order)
    {
        return _orderRepository.CreateOrder(order);
    }
}