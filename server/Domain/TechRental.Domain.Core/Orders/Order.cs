using TechRental.Domain.Common.Exceptions;
using TechRental.Domain.Core.Abstractions;
using TechRental.Domain.Core.Users;

#pragma warning disable CS8618

namespace TechRental.Domain.Core.Orders;

public class Order
{
    private decimal _totalPrice;

    protected Order()
    {
    }

    public Order(
        Guid id,
        User? user,
        string name,
        Image image,
        OrderStatus status,
        decimal total,
        DateTime? orderDate)
    {
        Id = id;
        User = user;
        UserId = user?.Id;
        Name = name;
        Image = image;
        Status = status;
        TotalPrice = total;
        OrderDate = orderDate;
    }

    public Guid Id { get; }
    public virtual User? User { get; set; }
    public Guid? UserId { get; set; }
    public string Name { get; }
    public Image Image { get; }
    public OrderStatus Status { get; set; }
    public DateTime? OrderDate { get; set; }

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