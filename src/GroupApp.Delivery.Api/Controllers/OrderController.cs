using GroupApp.Delivery.Application.UseCases.Orders.Create;
using GroupApp.Delivery.Application.UseCases.Orders.List;
using GroupApp.Delivery.Application.UseCases.Orders.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GroupApp.Delivery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-order")]
        public async Task<ActionResult<CreateOrderResponse>> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var result = await _mediator.Send(request);

            return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
        }

        [HttpPut("update-order-situation")]
        public async Task<ActionResult<UpdateOrderResponse>> UpdateOrderSituation([FromBody] UpdateOrderRequest request)
        {
            var result = await _mediator.Send(request);

            return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
        }

        [HttpGet("get-all-orders-to-delivery")]
        public async Task<ActionResult<ListOrdersResponse>> GetAllOrdersToDelivery()
        {
            var request = new ListOrdersRequest();

            var result = await _mediator.Send(request);

            return request.HasError
                ? BadRequest(result.Data)
                : Ok(result.Data);
        }
    }
}
