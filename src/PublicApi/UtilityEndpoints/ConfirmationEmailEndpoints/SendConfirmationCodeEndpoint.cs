﻿using System.Security.Claims;
using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Synword.Application.Exceptions;
using Synword.Application.Users.Commands;
using Synword.Persistence.Identity;

namespace Synword.PublicApi.UtilityEndpoints.ConfirmationEmailEndpoints;

public class SendConfirmationCodeEndpoint : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IMediator _mediator;
    private readonly UserManager<AppUser>? _userManager;

    public SendConfirmationCodeEndpoint(
        IMediator mediator,
        UserManager<AppUser>? userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
    }
    
    [HttpPost("sendConfirmationCode")]
    [Authorize]
    [SwaggerOperation(
        Tags = new[] { "Email" }
    )]
    public override async Task<ActionResult> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        AppUser? identityUser = 
            await _userManager!.FindByIdAsync(userId);
        Guard.Against.Null(identityUser);

        if (identityUser.EmailConfirmed)
        {
            throw new AppValidationException("Email already confirmed");
        }
        
        await _mediator.Send(
            new SendConfirmEmailCommand(identityUser),
            cancellationToken);
        
        return Ok("Confirmation code sent to email");
    }
}
