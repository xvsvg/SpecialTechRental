using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechRental.Application.Abstractions.Identity;
using TechRental.Application.Contracts.Identity.Commands;
using TechRental.Application.Contracts.Identity.Queries;
using TechRental.Presentation.Contracts.Identity;

namespace TechRental.Presentation.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController : ControllerBase
{
    private readonly IMediator _mediator;

    public IdentityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> LoginAsync([FromBody] LoginRequest request)
    {
        var query = new Login.Query(request.Username, request.Password);
        Login.Response response = await _mediator.Send(query, HttpContext.RequestAborted);

        var loginResponse = new LoginResponse(response.Token);
        return Ok(loginResponse);
    }

    [HttpPut("users/{username}/role")]
    [Authorize(Roles = TechRentalIdentityRoleNames.AdminRoleName)]
    public async Task<IActionResult> ChangeUserRoleAsync(string username, [FromQuery] string roleName)
    {
        var command = new ChangeUserRole.Command(username, roleName);
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPost("user/{id:guid}/create")]
    [Authorize(Roles = TechRentalIdentityRoleNames.AdminRoleName)]
    public async Task<IActionResult> CreateUserAccountAsync(Guid id, [FromBody] CreateUserAccountRequest request)
    {
        var command = new CreateUserAccount.Command(id, request.Username, request.Password, request.RoleName);
        await _mediator.Send(command);

        return Ok();
    }

    [HttpPut("username")]
    [Authorize]
    public async Task<ActionResult<UpdateUsernameResponse>> UpdateUsernameAsync([FromBody] UpdateUsernameRequest request)
    {
        var command = new UpdateUsername.Command(request.Username);
        var response = await _mediator.Send(command);

        return Ok(new UpdateUsernameResponse(response.Token));
    }

    [HttpPut("password")]
    [Authorize]
    public async Task<ActionResult<UpdatePasswordResponse>> UpdatePasswordAsync([FromBody] UpdatePasswordRequest request)
    {
        var command = new UpdatePassword.Command(request.CurrentPassword, request.NewPassword);
        var response = await _mediator.Send(command);

        return Ok(new UpdatePasswordResponse(response.Token));
    }
}