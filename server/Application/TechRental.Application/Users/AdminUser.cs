using TechRental.Application.Abstractions.Identity;

namespace TechRental.Application.Users;

internal class AdminUser : ICurrentUser
{
    public AdminUser(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }

    public bool CanCreateUserWithRole(string roleName)
    {
        return true;
    }

    public bool CanChangeUserRole(string currentRoleName, string newRoleName)
    {
        return true;
    }

    public bool CanManageOrders()
    {
        return true;
    }

    public bool CanManageBalance()
    {
        return false;
    }
}