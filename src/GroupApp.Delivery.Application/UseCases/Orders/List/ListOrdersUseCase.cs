using GroupApp.Delivery.Application.UseCases.Orders.List.Handlers;
using GroupApp.Delivery.Domain.Interfaces.Repositories;
using MediatR;

namespace GroupApp.Delivery.Application.UseCases.Orders.List;

public class ListOrdersUseCase : IRequestHandler<ListOrdersRequest, ListOrdersResponse>
{
    private readonly IOrderRepository _repository;

    public ListOrdersUseCase(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ListOrdersResponse> Handle(ListOrdersRequest request, CancellationToken cancellationToken)
    {
        var h1 = new GetOrdersHandler(_repository);

        await h1.Process(request);

        return new ListOrdersResponse
        {
            Data = request.HasError
                    ? request.ErrorMessage
                    : request.Orders,
        };
    }
}
