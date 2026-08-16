namespace HospitalManagementSystem.Application.Authentication.DTOs;

public record LoginUserDto
(
    int UserId,
    string Username,
    string Email,
    string PasswordHash,
    int RoleId,
    string RoleName,
    int FailedLoginAttempts,
    DateTime? LockoutEnd
);
