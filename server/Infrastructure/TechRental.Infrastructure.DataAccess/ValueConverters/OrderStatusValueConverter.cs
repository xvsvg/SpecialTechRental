using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechRental.Domain.Core.Abstractions;

namespace TechRental.Infrastructure.DataAccess.ValueConverters;

public class OrderStatusValueConverter : ValueConverter<OrderStatus, string>
{
    public OrderStatusValueConverter()
        : base(x => x.ToString(),
            x => Enum.Parse<OrderStatus>(x))
    {
    }
}