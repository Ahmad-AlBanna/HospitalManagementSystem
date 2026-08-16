using HospitalManagementSystem.Application.Authentication.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Interfaces.Services;
using HospitalManagementSystem.Application.Users.DTOs;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Data;

namespace HospitalManagementSystem.Application.Authentication.Commands;

public class LoginCommandHandler
    : IRequestHandler<LoginCommand, LoginResponseDto>
{
    private readonly IDapperExecutor _dapper;
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly ILogger<LoginCommandHandler> _logger;

    public LoginCommandHandler(
        IDapperExecutor dapper,
        ITokenService tokenService,
        IRefreshTokenService refreshTokenService,
        ILogger<LoginCommandHandler> logger)
    {
        _dapper = dapper;
        _tokenService = tokenService;
        _refreshTokenService = refreshTokenService;
        _logger = logger;
    }

    public async Task<LoginResponseDto> Handle(LoginCommand request,CancellationToken cancellationToken)
    {
        var user =
            await _dapper.QuerySingleOrDefaultAsync<LoginUserDto>(
                "dbo.User_GetByEmail",
                new
                {
                    request.Email
                }
                ,CommandType.StoredProcedure,cancellationToken);

        if (user is null)
        {
            _logger.LogWarning("Failed login attempt for email '{Email}'. User not found.",request.Email);
            throw new UnauthorizedAccessException(
                "Invalid email or password.");
        }

        var passwordValid = BCrypt.Net.BCrypt.Verify(request.Password,user.PasswordHash);

        if (!passwordValid)
        {
            await _dapper.ExecuteAsync(
                "dbo.User_LoginFailed",
                new
                {
                    user.UserId
                },
                CommandType.StoredProcedure,cancellationToken);


            _logger.LogWarning("Failed login attempt for email '{Email}'. Invalid password.",request.Email);
            throw new UnauthorizedAccessException(
                "Invalid email or password.");
        }

        var userDto = new UserDto(
            user.UserId,
            user.Username,
            user.Email,
            user.RoleId);

        var accessToken =_tokenService.GenerateToken(userDto,user.RoleName);

        var refreshToken =_refreshTokenService.GenerateRefreshToken(user.UserId);

        await _refreshTokenService.SaveRefreshToken(refreshToken);

        _logger.LogInformation(
            "User '{Email}' (Id: {UserId}, Role: {Role}) logged in successfully.",
            user.Email,
            user.UserId,
            user.RoleName);

        return new LoginResponseDto(
            userDto,
            accessToken,
            refreshToken.Token,
            refreshToken.ExpiryDate);
    }
}