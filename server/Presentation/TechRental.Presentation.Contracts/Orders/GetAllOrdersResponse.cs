using TechRental.Application.Dto.Orders;

namespace TechRental.Presentation.Contracts.Orders;

public record GetAllOrdersResponse(IEnumerable<UserOrderDto> Orders, int Page, int TotalPages);