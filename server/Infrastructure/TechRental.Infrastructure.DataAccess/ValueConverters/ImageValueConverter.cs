using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechRental.Domain.Core.Abstractions;

namespace TechRental.Infrastructure.DataAccess.ValueConverters;

public class ImageValueConverter : ValueConverter<UserImage, string>
{
    public ImageValueConverter()
        : base(
            x => (x.Value.LongLength == 0L ? string.Empty : x.Value.ToString()) ?? string.Empty,
            x => new UserImage(Convert.FromBase64String(x)))
    {
    }
}