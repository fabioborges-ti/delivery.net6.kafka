#nullable disable

using GroupApp.Delivery.Domain.Dtos.Http;
using GroupApp.Delivery.Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace GroupApp.Delivery.Application.UseCases.Orders.List;

public class ListOrdersRequest : RequestBaseDto, IRequest<ListOrdersResponse>
{
    [JsonIgnore]
    public List<Order> Orders { get; set; }
}
