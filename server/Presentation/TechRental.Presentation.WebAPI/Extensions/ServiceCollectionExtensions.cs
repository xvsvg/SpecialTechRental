using Microsoft.EntityFrameworkCore;
using TechRental.Application.Extensions;
using TechRental.Infrastructure.DataAccess.Extensions;
using TechRental.Infrastructure.Identity.Extensions;
using TechRental.Presentation.Controllers;
using TechRental.Presentation.WebAPI.Configuration;

namespace TechRental.Presentation.WebAPI.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection ConfigureServices(
        this IServiceCollection collection,
        WebApiConfiguration configuration,
        IConfigurationSection identityConfigurationSection)
    {
        collection
            .AddControllers()
            .AddApplicationPart(typeof(IControllerProjectMarker).Assembly)
            .AddControllersAsServices();

        string connectionString = configuration.PostgresConfiguration
            .ToConnectionString(configuration.DbNamesConfiguration.ApplicationDbName);

        collection
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddApplication()
            .AddDatabaseContext(o => o
                .UseNpgsql(connectionString));

        connectionString = configuration.PostgresConfiguration
            .ToConnectionString(configuration.DbNamesConfiguration.IdentityDbName);

        collection.AddIdentityConfiguration(
            identityConfigurationSection,
            o => o.UseNpgsql(
                configuration.PostgresConfiguration.ToConnectionString(connectionString)));

        return collection;
    }
}