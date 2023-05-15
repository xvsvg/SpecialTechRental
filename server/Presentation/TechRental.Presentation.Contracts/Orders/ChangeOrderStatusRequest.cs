namespace TechRental.Presentation.Contracts.Orders;

public record ChangeOrderStatusRequest(Guid OrderId, string Status);