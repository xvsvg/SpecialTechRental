using TechRental.Infrastructure.DataAccess.Configuration;

namespace TechRental.Presentation.WebAPI.Configuration;

internal class WebApiConfiguration
{
    private readonly string ASPNETCORE_ENVIRONMENT;

    public WebApiConfiguration(IConfiguration configuration)
    {
        if (configuration is null)
            throw new ArgumentNullException(nameof(configuration));

        ASPNETCORE_ENVIRONMENT = Environment
            .GetEnvironmentVariable(nameof(ASPNETCORE_ENVIRONMENT)) ?? "Development";

        var postgresConfiguration = configuration
            .GetSection(ASPNETCORE_ENVIRONMENT + nameof(PostgresConfiguration))
            .Get<PostgresConfiguration>();

        PostgresConfiguration = postgresConfiguration ??
                                throw new ArgumentException(nameof(PostgresConfiguration));

        var dbNameConfiguration = configuration
            .GetSection(nameof(DbNamesConfiguration))
            .Get<DbNamesConfiguration>();

        DbNamesConfiguration = dbNameConfiguration ??
                               throw new ArgumentException(nameof(DbNamesConfiguration));
    }

    public PostgresConfiguration PostgresConfiguration { get; set; }
    public DbNamesConfiguration DbNamesConfiguration { get; set; }
    public string EnvironmentVariable => ASPNETCORE_ENVIRONMENT;
}