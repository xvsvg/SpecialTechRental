using MediatR;
using Microsoft.EntityFrameworkCore;
using TechRental.DataAccess.Abstractions;
using TechRental.Infrastructure.Mapping.Orders;
using static TechRental.Application.Contracts.Orders.Queries.GetAllOrders;

namespace TechRental.Application.Handlers.Orders;

internal class GetAllOrdersHandler : IRequestHandler<Query, Response>
{
    private readonly IDatabaseContext _context;

    public GetAllOrdersHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.ToListAsync(cancellationToken);

        return new Response(order.ToDto());
    }
}