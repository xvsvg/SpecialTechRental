using MediatR;

namespace TechRental.Application.Contracts.Users.Commands;

internal static class MakeTransaction
{
    public record Command(decimal Total) : IRequest;
}