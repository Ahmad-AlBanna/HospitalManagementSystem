using HospitalManagementSystem.Domain.Entities;

namespace HospitalManagementSystem.Application.Interfaces.Services;

public interface IRefreshTokenService
{
    RefreshToken GenerateRefreshToken(int userId);

    Task SaveRefreshToken(RefreshToken refreshToken);

    Task<RefreshToken?> GetRefreshToken(string token);

    Task RevokeRefreshToken(string token);

    Task<RefreshToken> ValidateRefreshToken(string token);
}