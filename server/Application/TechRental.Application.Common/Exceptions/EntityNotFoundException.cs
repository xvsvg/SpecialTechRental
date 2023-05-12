namespace TechRental.Application.Common.Exceptions;

public class EntityNotFoundException : ApplicationException
{
    public EntityNotFoundException(string message) : base(message) { }

    public static EntityNotFoundException For<T>(Guid id)
        => new EntityNotFoundException($"Entity of type {typeof(T).Name} with id {id} was not found");
}