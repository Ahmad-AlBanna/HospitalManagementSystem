using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Authentication.DTOs;

public record RefreshTokenRequestDto
(
    [Required]
    string RefreshToken
);
