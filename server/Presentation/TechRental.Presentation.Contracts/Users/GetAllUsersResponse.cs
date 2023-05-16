using TechRental.Application.Dto.Users;

namespace TechRental.Presentation.Contracts.Users;

public record GetAllUsersResponse(IEnumerable<UserDto> Users, int Page, int TotalPages);