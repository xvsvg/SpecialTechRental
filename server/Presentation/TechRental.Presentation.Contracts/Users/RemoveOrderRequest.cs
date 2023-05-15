namespace TechRental.Presentation.Contracts.Users;

public record RemoveOrderRequest(Guid UserId, Guid OrderId);