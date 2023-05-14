using TechRental.Presentation.WebAPI.Configuration;
using TechRental.Presentation.WebAPI.Extensions;
using TechRental.Presentation.WebAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilogForAppLogs(builder.Configuration);

var webApiConfiguration = new WebApiConfiguration(builder.Configuration);
var identityConfigurationSection = builder.Configuration.GetSection("Identity:IdentityConfiguration");

builder.Services.ConfigureServices(
    webApiConfiguration,
    identityConfigurationSection);

var app = builder.Build().Configure();

using (var scope = app.Services.CreateScope())
{
    await SeedingHelper.SeedAdmins(scope.ServiceProvider, app.Configuration);
}

app.Run();
