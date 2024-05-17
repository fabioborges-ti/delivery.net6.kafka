#nullable disable

using GroupApp.Delivery.Domain.Enums;

namespace GroupApp.Delivery.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public DateTime OrderCreateDate { get; set; }
    public DateTime OrderLastUpdate { get; set; }
    public OrderStatus Status { get; set; }
    public Customer Customer { get; set; }
    public List<string> Items { get; set; }

    public Order(Customer customer, List<string> items)
    {
        Id = Guid.NewGuid();
        OrderCreateDate = DateTime.UtcNow;
        OrderLastUpdate = OrderCreateDate;
        Status = OrderStatus.CREATED;
        Items = items;
        Customer = customer;
    }

    public Order() { }
}
