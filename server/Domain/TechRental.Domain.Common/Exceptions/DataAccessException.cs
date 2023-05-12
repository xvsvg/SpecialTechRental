namespace TechRental.Domain.Common.Exceptions;

public class DataAccessException : InfrastructureException
{
    private DataAccessException() : base() { }

    private DataAccessException(string? message) : base(message) { }

    private DataAccessException(string? message, Exception innerException) : base(message, innerException) { }

    public static DataAccessException UnauthorizedException(string? message)
        => new DataAccessException(message);

    public static DataAccessException IdentityOperationNotSucceededException(string? message)
        => new DataAccessException(message);

    public static DataAccessException EntityNotFoundException(string? message)
        => new DataAccessException(message);
}