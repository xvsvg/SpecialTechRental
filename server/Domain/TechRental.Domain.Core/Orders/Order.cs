using TechRental.Domain.Common.Exceptions;
using TechRental.Domain.Core.Abstractions;

namespace TechRental.Domain.Core.Orders;

public class Order
{
    private decimal _totalPrice;

    public Order(
        Guid id,
        OrderStatus status,
        decimal total,
        DateTime orderDate)
    {
        Id = id;
        Status = status;
        TotalPrice = total;
        OrderDate = orderDate;
    }

    public Guid Id { get; }
    public OrderStatus Status { get; }
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