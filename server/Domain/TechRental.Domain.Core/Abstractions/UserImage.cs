namespace TechRental.Domain.Core.Abstractions;

public class UserImage
{
    private byte[] _image;

    public UserImage(byte[] image)
    {
        if (image.Length is 0)
            _image = Array.Empty<byte>();

        _image = image;
    }

    public byte[] Value => _image;
}