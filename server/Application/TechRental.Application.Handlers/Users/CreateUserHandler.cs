using MediatR;
using TechRental.DataAccess.Abstractions;
using TechRental.Domain.Core.Abstractions;
using TechRental.Domain.Core.Users;
using TechRental.Domain.Core.ValueObject;
using TechRental.Infrastructure.Mapping.Users;
using static TechRental.Application.Contracts.Users.Commands.CreateUser;

namespace TechRental.Application.Handlers.Users;

internal class CreateUserHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateUserHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var user = new User(
            Guid.NewGuid(),
            request.Firstname,
            request.Middlename,
            request.Lastname,
            new UserImage(request.UserImage),
            request.BirthDate,
            new PhoneNumber(request.PhoneNumber));

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(user.ToDto());
    }
}