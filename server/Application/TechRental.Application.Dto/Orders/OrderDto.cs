using TechRental.Application.Dto.Users;

namespace TechRental.Application.Dto.Orders;

public record OrderDto(
    Guid Id,
    UserDto? User,
    string Status,
    decimal Total,
    DateTime OrderDate);