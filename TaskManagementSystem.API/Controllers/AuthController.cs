using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManagementSystem.Application.Features.Authentication.CQRS.Commands;
using TaskManagementSystem.Application.Features.Authentication.CQRS.Queries;
using TaskManagementSystem.Application.Models.Identity;

namespace TaskManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("register")]
    public async Task<ActionResult> Register(RegistrationRequest registrationRequest)
    {
        var command = new RegistrationCommand { RegistrationRequest = registrationRequest };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(AuthRequest authRequest)
    {
        var command = new AuthQuery { AuthRequest = authRequest };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
