using MediatR;
using Microsoft.EntityFrameworkCore;
using TechRental.Application.Abstractions.Identity;
using TechRental.Application.Common.Exceptions;
using TechRental.DataAccess.Abstractions;
using TechRental.Domain.Core.Users;
using static TechRental.Application.Contracts.Users.Commands.MakeTransaction;

namespace TechRental.Application.Handlers.Users;

internal class MakeTransactionHandler : IRequestHandler<Command>
{
    private readonly IDatabaseContext _context;
    private readonly ICurrentUser _currentUser;

    public MakeTransactionHandler(IDatabaseContext context, ICurrentUser currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
        if (_currentUser.CanManageBalance() is false)
            throw UserHasNotAccessException.AnonymousUserHasNotAccess();

        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id.Equals(_currentUser.Id),
                cancellationToken);

        if (user is null)
            throw EntityNotFoundException.For<User>(_currentUser.Id);

        user.Money -= request.Total;
    }
}