using Microsoft.Extensions.DependencyInjection;

namespace TechRental.Application.Handlers.Extensions;

public static class RegistrationExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection collection)
    {
        collection.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(IAssemblyMarker)));

        return collection;
    }
}