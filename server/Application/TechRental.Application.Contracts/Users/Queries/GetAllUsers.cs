using MediatR;
using TechRental.Application.Dto.Users;

namespace TechRental.Application.Contracts.Users.Queries;

internal class GetAllUsers
{
    public record Query() : IRequest<Response>;

    public record Response(IEnumerable<UserDto> Users);
}