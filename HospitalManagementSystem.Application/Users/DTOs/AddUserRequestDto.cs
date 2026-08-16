using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Users.DTOs;

public record AddUserRequestDto
(
    [Required]
    [MaxLength(100)]
    string Username,

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    string Email,

    [Required]
    [MinLength(8)]
    string Password,

    [Range(1, int.MaxValue)]
    int RoleId
);