#nullable disable

using GroupApp.Delivery.Domain.Dtos.Http;
using GroupApp.Delivery.Domain.Entities;
using GroupApp.Delivery.Domain.Enums;
using MediatR;
using System.Text.Json.Serialization;

namespace GroupApp.Delivery.Application.UseCases.Orders.Update;

public class UpdateOrderRequest : RequestBaseDto, IRequest<UpdateOrderResponse>
{
    public Guid OrderId { get; set; }
    public OrderStatus Status { get; set; }

    [JsonIgnore]
    public Order Order { get; set; }
}
