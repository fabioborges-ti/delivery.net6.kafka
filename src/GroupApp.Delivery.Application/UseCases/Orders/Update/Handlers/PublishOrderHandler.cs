using GroupApp.Delivery.Application.Common;
using GroupApp.Delivery.Domain.Interfaces.Services;

namespace GroupApp.Delivery.Application.UseCases.Orders.Update.Handlers;

public class PublishOrderHandler : Handler<UpdateOrderRequest>
{
    private readonly IPublisherMessage _publisherMessage;

    public PublishOrderHandler(IPublisherMessage publisherMessage)
    {
        _publisherMessage = publisherMessage;
    }

    public override async Task Process(UpdateOrderRequest request)
    {
        if (request.HasError) return;

        try
        {
            var order = request.Order;

            await _publisherMessage.PublishMessageToTopic(order);
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;

            return;
        }
    }
}
