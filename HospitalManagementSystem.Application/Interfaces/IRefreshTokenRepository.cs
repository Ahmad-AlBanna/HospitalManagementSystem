using HospitalManagementSystem.Domain.Entities;

namespace HospitalManagementSystem.Application.Interfaces.Repositories;

public interface IRefreshTokenRepository
{
    Task SaveAsync(RefreshToken refreshToken);

    Task<RefreshToken?> GetByTokenAsync(string token);

    Task RevokeAsync(string token);
}
