using TechRental.Application.Dto.Users;

namespace TechRental.Application.Dto.Orders;

public record OrderDto(
    Guid Id,
    UserDto? User,
    string Name,
    byte[] Image,
    string Status,
    decimal Total,
    DateTime? OrderDate);