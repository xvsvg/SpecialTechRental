namespace TechRental.Domain.Common.Exceptions;

//401
public class UnauthorizedException : DomainException
{
    public UnauthorizedException(string message) : base(message) { }
}