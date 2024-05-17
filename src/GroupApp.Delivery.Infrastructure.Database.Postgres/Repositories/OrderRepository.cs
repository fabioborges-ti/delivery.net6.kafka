#nullable disable

using GroupApp.Delivery.Domain.Entities;
using GroupApp.Delivery.Domain.Enums;
using GroupApp.Delivery.Domain.Interfaces.Repositories;

namespace GroupApp.Delivery.Infrastructure.Database.Postgres.Repositories;

public class OrderRepository : IOrderRepository
{
    private static List<Order> _orderDataBase = new();

    public void Add(Order order)
    {
        _orderDataBase.Add(order);
    }

    public List<Order> GetAll()
    {
        return _orderDataBase.ToList();
    }

    public Order GetOrderById(Guid OrderId)
    {
        Order orderRecovered = _orderDataBase.FirstOrDefault(o => o.Id.Equals(OrderId));

        return orderRecovered is null
            ? throw new Exception("Order not found")
            : orderRecovered;
    }

    public List<Order> GetOrdersBySituation(OrderStatus status)
    {
        return _orderDataBase.Where(o => o.Status == status).ToList();
    }

    public void Update(Order order)
    {
        var id = order.Id;

        Order orderRecovered = GetOrderById(id);

        orderRecovered.Status = order.Status;
    }
}
