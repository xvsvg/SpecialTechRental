﻿using MediatR;
using TechRental.Application.Abstractions.Identity;
using TechRental.Domain.Common.Exceptions;
using static TechRental.Application.Contracts.Identity.Commands.UpdateUsername;

namespace TechRental.Application.Handlers.Identity;

internal class UpdateUsernameHandler : IRequestHandler<Command, Response>
{
    private readonly IAuthorizationService _authorizationService;
    private readonly ICurrentUser _currentUser;

    public UpdateUsernameHandler(ICurrentUser currentUser, IAuthorizationService authorizationService)
    {
        _currentUser = currentUser;
        _authorizationService = authorizationService;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var user = await _authorizationService.GetUserByIdAsync(_currentUser.Id, cancellationToken);

        if (user.Username.Equals(request.Username, StringComparison.Ordinal))
            throw UserInputException.UpdateUsernameFailedException("the old username is the same as the new one");

        await _authorizationService.UpdateUserNameAsync(_currentUser.Id, request.Username, cancellationToken);

        var token = await _authorizationService.GetUserTokenAsync(request.Username, cancellationToken);

        return new Response(token);
    }
}