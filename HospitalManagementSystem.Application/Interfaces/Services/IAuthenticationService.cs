using HospitalManagementSystem.Application.Authentication.DTOs;

namespace HospitalManagementSystem.Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<LoginResponseDto?> LoginAsync(
        LoginRequestDto request);
}