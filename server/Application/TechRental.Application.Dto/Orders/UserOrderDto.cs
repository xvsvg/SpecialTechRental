namespace TechRental.Application.Dto.Orders;

public record UserOrderDto(
    Guid Id,
    string Status,
    string Name,
    byte[] Image,
    decimal Total,
    DateTime? OrderDate);