using TechRental.Application.Dto.Orders;
using TechRental.Domain.Core.Orders;
using TechRental.Infrastructure.Mapping.Users;

namespace TechRental.Infrastructure.Mapping.Orders;

public static class OrderMapping
{
    public static IEnumerable<UserOrderDto> ToDto(this IEnumerable<Order> orders)
    {
        return orders.Select(order => order.ToUserOrderDto());
    }

    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto(
            order.Id,
            order.User.ToDto(),
            order.Status.ToString(),
            order.TotalPrice,
            order.OrderDate);
    }

    public static UserOrderDto ToUserOrderDto(this Order order)
    {
        return new UserOrderDto(
            order.Id,
            order.Status.ToString(),
            order.TotalPrice,
            order.OrderDate);
    }
}