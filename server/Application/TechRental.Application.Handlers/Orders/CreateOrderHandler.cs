﻿using MediatR;
using TechRental.Application.Abstractions.Identity;
using TechRental.Application.Common.Exceptions;
using TechRental.DataAccess.Abstractions;
using TechRental.Domain.Core.Abstractions;
using TechRental.Domain.Core.Orders;
using TechRental.Infrastructure.Mapping.Orders;
using static TechRental.Application.Contracts.Orders.Commands.CreateOrder;

namespace TechRental.Application.Handlers.Orders;

internal class CreateOrderHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;
    private readonly ICurrentUser _currentUser;

    public CreateOrderHandler(IDatabaseContext context, ICurrentUser currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        if (_currentUser.CanManageOrders() is false)
            throw AccessDeniedException.AccessViolation();

        var order = new Order(
            Guid.NewGuid(),
            null,
            request.Name,
            new Image(request.OrderImage),
            Enum.Parse<OrderStatus>(request.Status),
            request.Total,
            null);

        _context.Orders.Add(order);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(order.ToDto());
    }
}