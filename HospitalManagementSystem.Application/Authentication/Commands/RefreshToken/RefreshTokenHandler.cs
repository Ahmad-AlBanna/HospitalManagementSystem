using HospitalManagementSystem.Application.Authentication.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Interfaces.Services;
using HospitalManagementSystem.Application.Users.DTOs;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Authentication.Commands.RefreshToken;

public class RefreshTokenHandler
    : IRequestHandler<RefreshTokenCommand, LoginResponseDto>
{
    private readonly IDapperExecutor _dapper;
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenService _refreshTokenService;


    public RefreshTokenHandler(
        IDapperExecutor dapper,
        ITokenService tokenService,
        IRefreshTokenService refreshTokenService)
    {
        _dapper = dapper;
        _tokenService = tokenService;
        _refreshTokenService = refreshTokenService;
    }



    public async Task<LoginResponseDto> Handle(
        RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var storedToken =
            await _refreshTokenService.ValidateRefreshToken(
                request.RefreshToken);



        var user = await _dapper.QuerySingleOrDefaultAsync<UserDto>(
            "dbo.User_GetById",
            new
            {
                storedToken.UserId
            },
            CommandType.StoredProcedure,
            cancellationToken);



        if (user is null)
        {
            throw new UnauthorizedAccessException(
                "User not found.");
        }



        var accessToken =
            _tokenService.GenerateToken(user, "User");



        var newRefreshToken =
            _refreshTokenService.GenerateRefreshToken(
                user.UserId);



        await _refreshTokenService
            .SaveRefreshToken(newRefreshToken);



        await _refreshTokenService
            .RevokeRefreshToken(
                storedToken.Token);



        return new LoginResponseDto(
            user,
            accessToken,
            newRefreshToken.Token,
            newRefreshToken.ExpiryDate
        );
    }
}
