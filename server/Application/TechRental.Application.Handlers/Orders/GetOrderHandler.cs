using MediatR;
using Microsoft.EntityFrameworkCore;
using TechRental.Application.Common.Exceptions;
using TechRental.DataAccess.Abstractions;
using TechRental.Domain.Common.Exceptions;
using TechRental.Domain.Core.Orders;
using TechRental.Infrastructure.Mapping.Orders;
using static TechRental.Application.Contracts.Orders.Queries.GetOrder;

namespace TechRental.Application.Handlers.Orders;

internal class GetOrderHandler : IRequestHandler<Query, Response>
{
    private readonly IDatabaseContext _context;

    public GetOrderHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FindAsync(request.OrderId, cancellationToken);

        if (order is null)
            throw EntityNotFoundException.For<Order>(request.OrderId);

        return new Response(order.ToDto());
    }
}