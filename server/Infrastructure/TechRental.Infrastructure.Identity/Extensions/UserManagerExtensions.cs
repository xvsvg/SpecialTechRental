using Microsoft.AspNetCore.Identity;
using TechRental.Domain.Common.Exceptions;
using TechRental.Domain.Core.Users;
using TechRental.Infrastructure.Identity.Entities;

namespace TechRental.Infrastructure.Identity.Extensions;

internal static class UserManagerExtensions
{
    public static async Task<TechRentalIdentityUser> GetByIdAsync(
        this UserManager<TechRentalIdentityUser> userManager,
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());

        if (user is null)
            throw EntityNotFoundException.For<User>(userId);

        return user;
    }

    public static async Task<TechRentalIdentityUser> GetByNameAsync(
        this UserManager<TechRentalIdentityUser> userManager,
        string username,
        CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByNameAsync(username);

        if (user is null)
            throw EntityNotFoundException.For<User>(username);

        return user;
    }
}