namespace TechRental.Domain.Core.Abstractions;

public class UserImage
{
    public UserImage(byte[] image)
    {
        Value = image;
    }

    public byte[] Value { get; }
}