namespace TechRental.Domain.Core.Abstractions;

public class Image
{
    public Image(byte[] image)
    {
        Value = image;
    }

    public byte[] Value { get; }
}