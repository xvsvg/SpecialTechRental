using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechRental.Application.Abstractions.Identity;
using TechRental.Application.Contracts.Orders.Commands;
using TechRental.Application.Dto.Orders;
using TechRental.Presentation.Contracts.Orders;

namespace TechRental.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICurrentUser _currentUser;

    public OderController(IMediator mediator, ICurrentUser currentUser)
    {
        _mediator = mediator;
        _currentUser = currentUser;
    }

    [HttpPut("status")]
    [Authorize(Roles = TechRentalIdentityRoleNames.AdminRoleName)]
    public async Task<IActionResult> ChangeOrderStatusAsync([FromBody] ChangeOrderStatusRequest request)
    {
        var command = new ChangeOrderStatus.Command(request.OrderId, request.Status);
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<ActionResult<OrderDto>> CreateOrderAsync([FromBody] CreateOrderRequest request)
    {
        var command = new CreateOrder.Command(_currentUser.Id, request.Status, request.Total);
        var response = await _mediator.Send(command);

        return Ok(response.Order);
    }
}
