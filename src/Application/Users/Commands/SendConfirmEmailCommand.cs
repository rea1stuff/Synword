﻿using Ardalis.GuardClauses;
using MediatR;
using Synword.Application.Interfaces;
using Synword.Persistence.Identity;

namespace Synword.Application.Users.Commands;

public class SendConfirmEmailCommand : IRequest
{
    public SendConfirmEmailCommand(AppUser identityUser)
    {
        Guard.Against.Null(identityUser);
        
        IdentityUser = identityUser;
    }
    
    public AppUser IdentityUser { get; }
}

internal class SendConfirmEmailCommandHandler : IRequestHandler<SendConfirmEmailCommand>
{
    private readonly IEmailService _emailService;

    public SendConfirmEmailCommandHandler(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    public async Task<Unit> Handle(
        SendConfirmEmailCommand request, 
        CancellationToken cancellationToken)
    {
        AppUser identityUser = request.IdentityUser;

        string email = identityUser.Email;
        Guard.Against.NullOrEmpty(email);

        await SendConfirmationEmail(email);
        
        return Unit.Value;
    }
    
    private async Task SendConfirmationEmail(string email)
    {
        await _emailService.SendConfirmationEmailAsync(email);
    }
}
