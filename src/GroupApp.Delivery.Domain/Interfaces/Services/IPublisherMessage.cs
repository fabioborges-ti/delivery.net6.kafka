using GroupApp.Delivery.Domain.Entities;

namespace GroupApp.Delivery.Domain.Interfaces.Services;

public interface IPublisherMessage
{
    Task PublishMessageToTopic(Order order);
}