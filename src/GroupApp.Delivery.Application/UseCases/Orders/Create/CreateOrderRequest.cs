#nullable disable

using GroupApp.Delivery.Domain.Dtos.Http;
using GroupApp.Delivery.Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace GroupApp.Delivery.Application.UseCases.Orders.Create;

public class CreateOrderRequest : RequestBaseDto, IRequest<CreateOrderResponse>
{
    public Customer Customer { get; set; }
    public List<string> Items { get; set; }

    [JsonIgnore]
    public Order Order { get; set; }
}
