using TechRental.Application.Abstractions.Identity;
using TechRental.Application.Common.Exceptions;
using TechRental.Domain.Common.Exceptions;

namespace TechRental.Application.Users;

internal class AnonymousUser : ICurrentUser
{
    public Guid Id => throw new UnauthorizedException("Attempt to access anonymous user id");

    public bool CanCreateUserWithRole(string roleName)
    {
        return roleName.Equals(TechRentalIdentityRoleNames.DefaultUserRoleName, StringComparison.Ordinal)
                ? true
                : throw UserHasNotAccessException.AnonymousUserHasNotAccess();
    }

    public bool CanChangeUserRole(string currentRoleName, string newRoleName)
        => throw UserHasNotAccessException.AnonymousUserHasNotAccess();


    public bool CanManageOrders()
        => throw UserHasNotAccessException.AnonymousUserHasNotAccess();

    public bool CanManageBalance()
        => throw UserHasNotAccessException.AnonymousUserHasNotAccess();
}