using HospitalManagementSystem.Application.Authentication.Commands;
using HospitalManagementSystem.Application.Authentication.Commands.RefreshToken;
using HospitalManagementSystem.Application.Authentication.DTOs;
using HospitalManagementSystem.Application.Users.Commands.AddUser;
using HospitalManagementSystem.Application.Users.DTOs;
using HospitalManagementSystem.Infrastructure.Security.Policies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }


    // POST api/authentication/login
    // Anyone can login
    [HttpPost("login")]

    [AllowAnonymous]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequestDto dto)
    {
        var response = await _mediator.Send(
            new LoginCommand(
                dto.Email,
                dto.Password));

        return Ok(response);
    }



    // POST api/authentication/register
    // Only Admin can create users
    [HttpPost("register")]
    [Authorize(Policy = AuthorizationPolicies.AdminOnly)]
    public async Task<IActionResult> Register(
       [FromBody] AddUserRequestDto dto)
    {
        var userId = await _mediator.Send(
            new AddUserCommand(
                dto.Username,
                dto.Email,
                dto.Password,
                dto.RoleId));

        return Ok(new
        {
            UserId = userId
        });
    }



    // POST api/authentication/refresh-token
    // Anyone with a valid refresh token
    [HttpPost("refresh-token")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken(
        [FromBody] RefreshTokenRequestDto dto)
    {
        var response = await _mediator.Send(
            new RefreshTokenCommand(dto.RefreshToken));

        return Ok(response);
    }
}
