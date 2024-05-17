using GroupApp.Delivery.Domain.Entities;

namespace GroupApp.Delivery.Domain.Interfaces.Services;

public interface INotifierService
{
    void Notify(Order order);
}
