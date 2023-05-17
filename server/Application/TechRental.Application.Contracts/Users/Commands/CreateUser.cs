using MediatR;
using TechRental.Application.Dto.Users;

namespace TechRental.Application.Contracts.Users.Commands;

internal static class CreateUser
{
    public record Command(Guid IdentityId, string Firstname, string Middlename, string Lastname, byte[] UserImage, DateTime BirthDate,
        string PhoneNumber) : IRequest<Response>;

    public record Response(UserDto User);
}