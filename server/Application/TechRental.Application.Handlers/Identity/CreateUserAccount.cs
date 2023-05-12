using MediatR;
using TechRental.Application.Abstractions.Identity;
using TechRental.Application.Common;
using TechRental.Application.Common.Exceptions;
using TechRental.DataAccess.Abstractions;
using TechRental.Domain.Core.Users;
using static TechRental.Application.Contracts.Identity.Commands.CreateUserAccount;

namespace TechRental.Application.Handlers.Identity;

internal class CreateUserAccount : IRequestHandler<Command>
{
    private readonly IDatabaseContext _context;
    private readonly ICurrentUser _currentUser;
    private readonly IAuthorizationService _authorizationService;

    public CreateUserAccount(
        IDatabaseContext context,
        IAuthorizationService authorizationService,
        ICurrentUser currentUser)
    {
        _context = context;
        _authorizationService = authorizationService;
        _currentUser = currentUser;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
        if (_context.Users.Any(x => x.Id.Equals(request.UserId)) is false)
            throw EntityNotFoundException.For<User>(request.UserId);

        if (_currentUser.CanCreateUserWithRole(request.Rolename) is false)
            throw new AccessDeniedException(
                $"User {_currentUser.Id} is not allowed to create user with role {request.Rolename}");

        await _authorizationService.CreateUserAsync(
            request.UserId,
            request.Username,
            request.Password,
            request.Rolename,
            cancellationToken);
    }
}