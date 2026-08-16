

using System.Data;
using System.Security.Cryptography;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Interfaces.Services;
using HospitalManagementSystem.Domain.Entities;

namespace HospitalManagementSystem.Infrastructure.Security.TokenService;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly IDapperExecutor _dapper;

    public RefreshTokenService(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }

    public RefreshToken GenerateRefreshToken(int userId)
    {
        return new RefreshToken
        {
            UserId = userId,

            Token = Convert.ToBase64String(
                RandomNumberGenerator.GetBytes(64)),

            ExpiryDate = DateTime.UtcNow.AddDays(7),

            IsRevoked = false
        };
    }

    public Task SaveRefreshToken(
        RefreshToken refreshToken)
    {
        return _dapper.ExecuteAsync(
            "dbo.RefreshToken_Create",
            new
            {
                refreshToken.UserId,
                refreshToken.Token,
                refreshToken.ExpiryDate,
                refreshToken.IsRevoked
            },
            CommandType.StoredProcedure);
    }

    public Task<RefreshToken?> GetRefreshToken(
        string token)
    {
        return _dapper.QuerySingleOrDefaultAsync<RefreshToken>(
            "dbo.RefreshToken_GetByToken",
            new
            {
                Token = token
            },
            CommandType.StoredProcedure);
    }

    public Task RevokeRefreshToken(
        string token)
    {
        return _dapper.ExecuteAsync(
            "dbo.RefreshToken_Revoke",
            new
            {
                Token = token
            },
            CommandType.StoredProcedure);
    }

    public async Task<RefreshToken> ValidateRefreshToken(
        string token)
    {
        var refreshToken =
            await GetRefreshToken(token);

        if (refreshToken is null)
        {
            throw new UnauthorizedAccessException(
                "Invalid refresh token.");
        }

        if (refreshToken.IsRevoked)
        {
            throw new UnauthorizedAccessException(
                "Refresh token has been revoked.");
        }

        if (refreshToken.ExpiryDate <= DateTime.UtcNow)
        {
            throw new UnauthorizedAccessException(
                "Refresh token has expired.");
        }

        return refreshToken;
    }
}
























































//using System.Security.Cryptography;
//using HospitalManagementSystem.Application.Interfaces.Repositories;
//using HospitalManagementSystem.Application.Interfaces.Services;
//using HospitalManagementSystem.Domain.Entities;

//namespace HospitalManagementSystem.Infrastructure.Security.TokenService;

//public class RefreshTokenService : IRefreshTokenService
//{
//    private readonly IRefreshTokenRepository _refreshTokenRepository;


//    public RefreshTokenService(
//        IRefreshTokenRepository refreshTokenRepository)
//    {
//        _refreshTokenRepository = refreshTokenRepository;
//    }


//    public RefreshToken GenerateRefreshToken(int userId)
//    {
//        return new RefreshToken
//        {
//            UserId = userId,

//            Token = Convert.ToBase64String(
//                RandomNumberGenerator.GetBytes(64)),

//            ExpiryDate = DateTime.UtcNow.AddDays(7),

//            IsRevoked = false
//        };
//    }


//    public Task SaveRefreshToken(
//        RefreshToken refreshToken)
//    {
//        return _refreshTokenRepository
//            .SaveAsync(refreshToken);
//    }


//    public Task<RefreshToken?> GetRefreshToken(
//        string token)
//    {
//        return _refreshTokenRepository
//            .GetByTokenAsync(token);
//    }


//    public Task RevokeRefreshToken(
//        string token)
//    {
//        return _refreshTokenRepository
//            .RevokeAsync(token);
//    }


//    public async Task<RefreshToken> ValidateRefreshToken(
//        string token)
//    {
//        var refreshToken =
//            await _refreshTokenRepository
//                .GetByTokenAsync(token);


//        if (refreshToken is null)
//        {
//            throw new UnauthorizedAccessException(
//                "Invalid refresh token.");
//        }


//        if (refreshToken.IsRevoked)
//        {
//            throw new UnauthorizedAccessException(
//                "Refresh token has been revoked.");
//        }


//        if (refreshToken.ExpiryDate <= DateTime.UtcNow)
//        {
//            throw new UnauthorizedAccessException(
//                "Refresh token has expired.");
//        }


//        return refreshToken;
//    }
//}