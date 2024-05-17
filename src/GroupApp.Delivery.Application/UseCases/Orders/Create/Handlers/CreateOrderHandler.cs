using GroupApp.Delivery.Application.Common;
using GroupApp.Delivery.Domain.Entities;
using GroupApp.Delivery.Domain.Interfaces.Repositories;

namespace GroupApp.Delivery.Application.UseCases.Orders.Create.Handlers;

public class CreateOrderHandler : Handler<CreateOrderRequest>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public override async Task Process(CreateOrderRequest request)
    {
        try
        {
            var order = new Order
            {
                Customer = request.Customer,
                Items = request.Items
            };

            _orderRepository.Add(order);

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
