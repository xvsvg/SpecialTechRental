using MediatR;

namespace TechRental.Application.Contracts.Identity.Queries;

internal static class GetRole
{
    public record Query(Guid Id) : IRequest<Response>;

    public record Response(string Role);
}