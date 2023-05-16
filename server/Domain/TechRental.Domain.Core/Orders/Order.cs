using TechRental.Domain.Common.Exceptions;
using TechRental.Domain.Core.Abstractions;
using TechRental.Domain.Core.Users;
#pragma warning disable CS8618

namespace TechRental.Domain.Core.Orders;

public class Order
{
    private decimal _totalPrice;

    protected Order() { }

    public Order(
        Guid id,
        User? user,
        OrderStatus status,
        decimal total,
        DateTime orderDate)
    {
        Id = id;
        User = user;
        Status = status;
        TotalPrice = total;
        OrderDate = orderDate;
    }

    public Guid Id { get; }
    public User? User { get; }
    public OrderStatus Status { get; set; }
    public DateTime OrderDate { get; }

    public decimal TotalPrice
    {
        get => _totalPrice;

        set
        {
            if (value < 0)
                throw UserInputException.NegativeOrderTotalException();

            _totalPrice = value;
        }
    }
}