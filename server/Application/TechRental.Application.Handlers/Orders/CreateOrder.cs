using MediatR;
using TechRental.Application.Common.Exceptions;
using TechRental.DataAccess.Abstractions;
using TechRental.Domain.Core.Abstractions;
using TechRental.Domain.Core.Orders;
using TechRental.Domain.Core.Users;
using TechRental.Infrastructure.Mapping.Orders;
using static TechRental.Application.Contracts.Orders.Commands.CreateOrder;

namespace TechRental.Application.Handlers.Orders;

internal class CreateOrder : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateOrder(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.UserId, cancellationToken);

        if (user is null)
            throw EntityNotFoundException.For<User>(request.UserId);

        var order = new Order(
            Guid.NewGuid(),
            user,
            Enum.Parse<OrderStatus>(request.Status),
            request.Total,
            DateTime.UtcNow);

        _context.Orders.Add(order);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(order.ToDto());
    }
}