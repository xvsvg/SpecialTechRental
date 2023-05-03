using TechRental.Application.Dto.Users;
using TechRental.Domain.Core.Users;
using TechRental.Infrastructure.Mapping.Orders;

namespace TechRental.Infrastructure.Mapping.Users;

public static class UserMapping
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto(
            user.Id,
            user.FirstName,
            user.MiddleName,
            user.LastName,
            user.Image.Value,
            user.BirthDate,
            user.PhoneNumber.Value,
            user.Orders.ToDto());
    }
}