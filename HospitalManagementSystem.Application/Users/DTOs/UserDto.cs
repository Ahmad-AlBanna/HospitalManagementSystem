namespace HospitalManagementSystem.Application.Users.DTOs;

public record UserDto
(
    int UserId,
    string Username,
    string Email,
    int RoleId
);
