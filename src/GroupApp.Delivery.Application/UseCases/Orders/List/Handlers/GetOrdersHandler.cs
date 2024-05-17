using GroupApp.Delivery.Application.Common;
using GroupApp.Delivery.Domain.Interfaces.Repositories;

namespace GroupApp.Delivery.Application.UseCases.Orders.List.Handlers;

public class GetOrdersHandler : Handler<ListOrdersRequest>
{
    private readonly IOrderRepository _repository;

    public GetOrdersHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public override async Task Process(ListOrdersRequest request)
    {
        try
        {
            var orders = _repository.GetAll();

            request.Orders = orders;
        }
        catch (Exception ex)
        {
            request.HasError = true;
            request.ErrorMessage = ex.Message;

            return;
        }
    }
}
