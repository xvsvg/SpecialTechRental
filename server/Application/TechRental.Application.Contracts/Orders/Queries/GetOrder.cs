﻿using MediatR;
using TechRental.Application.Dto.Orders;

namespace TechRental.Application.Contracts.Orders.Queries;

internal static class GetOrder
{
    public record Query(Guid OrderId) : IRequest<Response>;

    public record Response(OrderDto Order);
}