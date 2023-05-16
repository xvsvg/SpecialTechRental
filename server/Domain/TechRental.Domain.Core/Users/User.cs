using TechRental.Domain.Common.Exceptions;
using TechRental.Domain.Core.Abstractions;
using TechRental.Domain.Core.Orders;
using TechRental.Domain.Core.ValueObject;
#pragma warning disable CS8618

namespace TechRental.Domain.Core.Users;

public class User
{
    private readonly List<Order> _orders;
    private decimal _money;

    protected User() { }

    public User(
        Guid id,
        string firstName,
        string middleName,
        string lastName,
        UserImage image,
        DateTime birthDate,
        PhoneNumber phoneNumber)
    {
        ArgumentNullException.ThrowIfNull(firstName);
        ArgumentNullException.ThrowIfNull(middleName);
        ArgumentNullException.ThrowIfNull(lastName);
        ArgumentNullException.ThrowIfNull(image);
        ArgumentNullException.ThrowIfNull(phoneNumber);

        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Image = image;
        MiddleName = middleName;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;

        _orders = new List<Order>();
        Money = 0;
    }

    public Guid Id { get; }
    public string FirstName { get; }
    public string MiddleName { get; }
    public string LastName { get; }
    public UserImage Image { get; }
    public DateTime BirthDate { get; }
    public PhoneNumber PhoneNumber { get; }
    public IEnumerable<Order> Orders => _orders;
    public decimal Money
    {
        get => _money;
        set
        {
            if (value < 0)
                throw UserInputException.NegativeUserBalanceException();

            _money = value;
        }
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName} {MiddleName}";
    }

    public Order AddOrder(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);

        _orders.Add(order);

        return order;
    }

    public void RemoveOrder(Order order)
        => _orders.Remove(order);
}