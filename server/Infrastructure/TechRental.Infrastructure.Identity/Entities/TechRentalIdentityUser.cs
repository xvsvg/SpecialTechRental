using Microsoft.AspNetCore.Identity;
using TechRental.Application.Dto.Identity;

namespace TechRental.Infrastructure.Identity.Entities;

internal class TechRentalIdentityUser : IdentityUser<Guid>
{
    public IdentityUserDto ToDto()
    {
        return new IdentityUserDto(Id, UserName ?? string.Empty);
    }
}