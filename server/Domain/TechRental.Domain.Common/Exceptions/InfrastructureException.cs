namespace TechRental.Domain.Common.Exceptions;

public abstract class InfrastructureException : Exception
{
    protected InfrastructureException() : base() { }

    protected InfrastructureException(string? message) : base(message) { }

    protected InfrastructureException(string? message, Exception innerException) : base(message, innerException) { }
}