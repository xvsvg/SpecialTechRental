using MediatR;
using TechRental.Application.Dto.Orders;

namespace TechRental.Application.Contracts.Orders.Queries;

internal class GetAllOrders
{
    public record Query() : IRequest<Response>;

    public record Response(IEnumerable<UserOrderDto> Orders);
}