using GroupApp.Delivery.Domain.Entities;
using GroupApp.Delivery.Domain.Enums;

namespace GroupApp.Delivery.Domain.Interfaces.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    void Update(Order order);
    List<Order> GetAll();
    Order GetOrderById(Guid OrderId);
    List<Order> GetOrdersBySituation(OrderStatus orderSituation);
}
