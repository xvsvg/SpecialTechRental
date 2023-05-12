using MediatR;

namespace TechRental.Application.Contracts.Identity.Commands;

internal static class CreateUserAccount
{
    public record Command(Guid UserId, string Username, string Password, string RoleName) : IRequest;
}