using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechRental.Application.Abstractions.Identity;
using TechRental.Application.Contracts.Users.Commands;
using TechRental.Application.Contracts.Users.Queries;
using TechRental.Application.Dto.Users;
using TechRental.Presentation.Contracts.Users;

namespace TechRental.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    [Authorize(Roles = TechRentalIdentityRoleNames.AdminRoleName)]
    public async Task<ActionResult<UserDto>> CreateUserAsync([FromBody] CreateUserRequest request)
    {
        var command = new CreateUser.Command(
            request.FirstName ?? string.Empty,
            request.MiddleName ?? string.Empty,
            request.LastName ?? string.Empty,
            Convert.FromBase64String(request.UserImage ?? string.Empty),
            request.BirthDate,
            request.PhoneNumber ?? string.Empty);

        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPost("new-order")]
    [Authorize]
    public async Task<IActionResult> AddOrderAsync([FromBody] AddOrderRequest request)
    {
        var command = new AddOrder.Command(request.OrderId, request.UserId);
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPost("remove-order")]
    [Authorize(Roles = TechRentalIdentityRoleNames.AdminRoleName)]
    public async Task<IActionResult> AddOrderAsync([FromBody] RemoveOrderRequest request)
    {
        var command = new RemoveOrder.Command(request.OrderId, request.UserId);
        await _mediator.Send(command);

        return Ok();
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = TechRentalIdentityRoleNames.AdminRoleName)]
    public async Task<ActionResult<UserDto>> GetUserAsync(Guid id)
    {
        var query = new GetUser.Query(id);
        var response = await _mediator.Send(query);

        return Ok(response.User);
    }
}
