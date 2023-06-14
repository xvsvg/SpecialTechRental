namespace TechRental.Application.Common.Exceptions;

public class AccessDeniedException : ApplicationException
{
    public AccessDeniedException() : base("Access denied")
    {
    }

    private AccessDeniedException(string message)
        : base(message)
    {
    }

    public static AccessDeniedException AccessViolation(Guid userId)
    {
        return new AccessDeniedException($"User {userId} has not access to this field");
    }

    public static AccessDeniedException AccessViolation()
    {
        return new AccessDeniedException("User has not access to this field");
    }

    public static AccessDeniedException AnonymousUserHasNotAccess()
    {
        return new AccessDeniedException("Anonymous user cannot have an access to this information");
    }

    public static AccessDeniedException NotInRoleException()
    {
        return new AccessDeniedException("User hasn't got a privilege for this operation.");
    }
}