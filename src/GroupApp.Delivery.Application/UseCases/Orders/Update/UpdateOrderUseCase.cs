using GroupApp.Delivery.Application.UseCases.Orders.Update.Handlers;
using GroupApp.Delivery.Domain.Interfaces.Repositories;
using GroupApp.Delivery.Domain.Interfaces.Services;
using MediatR;

namespace GroupApp.Delivery.Application.UseCases.Orders.Update;

public class UpdateOrderUseCase : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPublisherMessage _publisherMessage;

    public UpdateOrderUseCase(IOrderRepository orderRepository, IPublisherMessage publisherMessage)
    {
        _orderRepository = orderRepository;
        _publisherMessage = publisherMessage;
    }

    public async Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetOrderHandler(_orderRepository);
        var h2 = new UpdateOrderHandler(_orderRepository);
        var h3 = new PublishOrderHandler(_publisherMessage);

        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);

        await h1.Process(request);

        return new UpdateOrderResponse
        {
            Data = request.HasError
                    ? "Ocorreu algum erro na edição do pedido."
                    : "Pedido atualizado com sucesso."
        };
    }
}
