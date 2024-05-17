using GroupApp.Delivery.Application.UseCases.Orders.Create.Handlers;
using GroupApp.Delivery.Domain.Interfaces.Repositories;
using GroupApp.Delivery.Domain.Interfaces.Services;
using MediatR;

namespace GroupApp.Delivery.Application.UseCases.Orders.Create;

public class CreateOrderUseCase : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPublisherMessage _publisher;

    public CreateOrderUseCase(IOrderRepository orderRepository, IPublisherMessage publisher)
    {
        _orderRepository = orderRepository;
        _publisher = publisher;
    }

    public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var h1 = new CreateOrderHandler(_orderRepository);
        var h2 = new PublishOrderHandler(_publisher);

        h1.SetSuccessor(h2);

        await h1.Process(request);

        return new CreateOrderResponse
        {
            Data = request.HasError
                    ? "Erro ao gravar o pedido"
                    : "Pedido criado com sucesso"
        };
    }
}
