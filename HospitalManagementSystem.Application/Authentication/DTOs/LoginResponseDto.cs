using HospitalManagementSystem.Application.Users.DTOs;

namespace HospitalManagementSystem.Application.Authentication.DTOs;

public record LoginResponseDto
(
    UserDto User,
    string AccessToken,
    string RefreshToken,
    DateTime ExpiresAt
);
