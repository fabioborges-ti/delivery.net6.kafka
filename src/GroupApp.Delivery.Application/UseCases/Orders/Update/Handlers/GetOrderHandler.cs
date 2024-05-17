using GroupApp.Delivery.Application.Common;
using GroupApp.Delivery.Domain.Interfaces.Repositories;

namespace GroupApp.Delivery.Application.UseCases.Orders.Update.Handlers;

public class GetOrderHandler : Handler<UpdateOrderRequest>
{
    private readonly IOrderRepository _repository;

    public GetOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(UpdateOrderRequest request)
    {
        try
        {
            var id = request.OrderId;

            var order = _repository.GetOrderById(id);

            if (order is null)
            {
                request.HasError = true;
                request.ErrorMessage = "Pedido não encontrado";

                return;
            }

            request.Order = order;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.ToString();

            return;
        }

        await _successor!.Process(request);
    }
}
