﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TechRental.Application.Extensions;
using TechRental.Infrastructure.DataAccess.Extensions;
using TechRental.Infrastructure.Identity.Extensions;
using TechRental.Presentation.Controllers;
using TechRental.Presentation.Middlewares;
using TechRental.Presentation.WebAPI.Configuration;

namespace TechRental.Presentation.WebAPI.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection ConfigureServices(
        this IServiceCollection collection,
        WebApiConfiguration webApiConfiguration,
        IConfigurationSection identityConfigurationSection,
        IConfiguration configuration)
    {
        collection
            .AddControllers()
            .AddApplicationPart(typeof(IControllerProjectMarker).Assembly)
            .AddControllersAsServices();

        var connectionString = webApiConfiguration.PostgresConfiguration
            .ToConnectionString(webApiConfiguration.DbNamesConfiguration.ApplicationDbName);

        collection
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(c =>
            {
                var openApiSecurityScheme = new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                };

                c.AddSecurityDefinition("Bearer", openApiSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                var xmlFilename = $"{typeof(IControllerProjectMarker).Assembly.GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            })
            .AddApplication(configuration)
            .AddDatabaseContext(o => o
                .UseNpgsql(connectionString));

        collection.AddIdentityConfiguration(
            identityConfigurationSection,
            o => o.UseNpgsql(
                webApiConfiguration.PostgresConfiguration.ToConnectionString(webApiConfiguration.DbNamesConfiguration
                    .IdentityDbName)));

        collection.AddTransient<ExceptionHandlingMiddleware>();

        return collection;
    }
}