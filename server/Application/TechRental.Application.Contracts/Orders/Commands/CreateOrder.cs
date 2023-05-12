using MediatR;
using TechRental.Application.Dto.Orders;

namespace TechRental.Application.Contracts.Orders.Commands;

internal static class CreateOrder
{
    public record Command(Guid UserId, string Status, decimal Total) : IRequest<Response>;

    public record Response(OrderDto Order);
}