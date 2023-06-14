using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechRental.Domain.Core.ValueObject;

namespace TechRental.Infrastructure.DataAccess.ValueConverters;

public class PhoneNumberValueConverter : ValueConverter<PhoneNumber, string>
{
    public PhoneNumberValueConverter()
        : base(x => x.Value, x => new PhoneNumber(x))
    {
    }
}