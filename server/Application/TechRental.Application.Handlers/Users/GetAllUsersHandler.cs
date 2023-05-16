using MediatR;
using Microsoft.EntityFrameworkCore;
using TechRental.DataAccess.Abstractions;
using TechRental.Infrastructure.Mapping.Users;
using static TechRental.Application.Contracts.Users.Queries.GetAllUsers;

namespace TechRental.Application.Handlers.Users;

internal class GetAllUsersHandler : IRequestHandler<Query, Response>
{
    private readonly IDatabaseContext _context;

    public GetAllUsersHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var users = await _context.Users.ToListAsync(cancellationToken);

        return new Response(users.ToDto());
    }
}