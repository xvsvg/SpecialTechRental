using MediatR;

namespace TechRental.Application.Contracts.Orders.Commands;

internal static class ChangeOrderStatus
{
    public record Command(Guid OrderId, string Status) : IRequest;
}