using GroupApp.Delivery.Application.Common;
using GroupApp.Delivery.Domain.Interfaces.Services;

namespace GroupApp.Delivery.Application.UseCases.Orders.Create.Handlers;

public class PublishOrderHandler : Handler<CreateOrderRequest>
{
    private readonly IPublisherMessage _publisher;

    public PublishOrderHandler(IPublisherMessage publisher)
    {
        _publisher = publisher;
    }

    public override async Task Process(CreateOrderRequest request)
    {
        if (request.HasError) return;

        try
        {
            var order = request.Order;

            await _publisher.PublishMessageToTopic(order);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;

            return;
        }
    }
}
