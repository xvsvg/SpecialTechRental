namespace TechRental.Presentation.WebAPI.Extensions;

internal static class WebApplicationExtensions
{
    internal static WebApplication Configure(this WebApplication app)
    {
        app
            .UseSwagger()
            .UseSwaggerUI();

        app
            .UseRouting()
            .UseAuthentication()
            .UseAuthorization();

        app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        app.MapControllers();

        return app;
    }
}
