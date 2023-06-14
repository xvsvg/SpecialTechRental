using Microsoft.AspNetCore.Identity;
using TechRental.Domain.Common.Exceptions;

namespace TechRental.Infrastructure.Identity.Extensions;

internal static class IdentityResultExtensions
{
    public static void EnsureSucceeded(this IdentityResult result)
    {
        if (result.Succeeded is false)
            throw UserInputException.IdentityOperationNotSucceededException(
                string.Join(' ',
                    result.Errors.Select(x => x.Description)));
    }
}