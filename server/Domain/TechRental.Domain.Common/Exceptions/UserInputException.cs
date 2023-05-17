namespace TechRental.Domain.Common.Exceptions;

//400
public class UserInputException : DomainException
{
    private UserInputException() : base() { }

    private UserInputException(string message)
        : base(message) { }

    public static UserInputException InvalidPhoneNumberException(string message)
        => new UserInputException(message);

    public static UserInputException NegativeOrderTotalException()
        => new UserInputException();

    public static UserInputException NegativeUserBalanceException(string message)
        => new UserInputException(message);

    public static UserInputException UpdateUsernameFailedException(string message)
        => new UserInputException(message);

    public static UserInputException IdentityOperationNotSucceededException(string message)
        => new UserInputException(message);
}