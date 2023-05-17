using System.Net;
using System.Text.Json;
using TechRental.Application.Common.Exceptions;
using TechRental.Domain.Common.Exceptions;

namespace TechRental.Presentation.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly Dictionary<Type, HttpStatusCode> _mappings;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;

        _mappings = InitializeMappings();
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            if (_mappings.ContainsKey(ex.GetType()))
                context.Response.StatusCode = (int)_mappings[ex.GetType()];

            var problem = GetProblem(context, ex);

            await context.Response.WriteAsJsonAsync(
                problem,
                problem.GetType(),
                new JsonSerializerOptions(),
                "application/problem+json");
        }
    }

    private static object GetProblem(HttpContext context, Exception ex)
    {
        return new
        {
            Type = ex.GetType().Name,
            Detailes = ex.Message,
            Status = context.Response.StatusCode,
            HelpLink = ex.HelpLink,
        };
    }

    private Dictionary<Type, HttpStatusCode> InitializeMappings()
    {
        return new Dictionary<Type, HttpStatusCode>
        {
            {typeof(EntityNotFoundException), HttpStatusCode.NotFound },
            {typeof(UnauthorizedException), HttpStatusCode.Unauthorized },
            {typeof(UserInputException), HttpStatusCode.BadRequest },
            {typeof(AccessDeniedException), HttpStatusCode.Forbidden }
        };
    }
}
