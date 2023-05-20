using MediatR;
using TechRental.Application.Abstractions.Identity;
using static TechRental.Application.Contracts.Identity.Queries.GetRole;

namespace TechRental.Application.Handlers.Identity;

internal class GetRoleHandler : IRequestHandler<Query, Response>
{
    private readonly IAuthorizationService _authorizationService;

    public GetRoleHandler(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var response = await _authorizationService.GetUserRoleAsync(request.Id, cancellationToken);

        return new Response(response);
    }
}