namespace TechRental.Domain.Common.Exceptions;

public class UserInputException : DomainException
{
    private UserInputException()
    {
    }

    private UserInputException(string message)
        : base(message)
    {
    }

    public static UserInputException InvalidPhoneNumberException(string message)
    {
        return new UserInputException(message);
    }

    public static UserInputException NegativeOrderTotalException()
    {
        return new UserInputException();
    }

    public static UserInputException NegativeUserBalanceException(string message)
    {
        return new UserInputException(message);
    }

    public static UserInputException UpdateUsernameFailedException(string message)
    {
        return new UserInputException(message);
    }

    public static UserInputException IdentityOperationNotSucceededException(string message)
    {
        return new UserInputException(message);
    }
}