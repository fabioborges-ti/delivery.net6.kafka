using GroupApp.Delivery.Application.Common;
using GroupApp.Delivery.Domain.Interfaces.Repositories;

namespace GroupApp.Delivery.Application.UseCases.Orders.Update.Handlers;

internal class UpdateOrderHandler : Handler<UpdateOrderRequest>
{
    private readonly IOrderRepository _repository;

    public UpdateOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(UpdateOrderRequest request)
    {
        if (request.HasError) return;

        try
        {
            var order = request.Order;

            order.Status = request.Status;
            order.OrderLastUpdate = DateTime.UtcNow;

            _repository.Update(order);

            request.Order = order;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;

            return;
        }

        await _successor!.Process(request);
    }
}
