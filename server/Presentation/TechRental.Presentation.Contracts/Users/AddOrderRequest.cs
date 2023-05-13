namespace TechRental.Presentation.Contracts.Users;

public record AddOrderRequest(Guid UserId, Guid OrderId);