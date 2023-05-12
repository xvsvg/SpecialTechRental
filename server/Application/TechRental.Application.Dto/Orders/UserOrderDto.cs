namespace TechRental.Application.Dto.Orders;

public record UserOrderDto(
    Guid Id,
    string Status,
    decimal Total,
    DateTime OrderDate);