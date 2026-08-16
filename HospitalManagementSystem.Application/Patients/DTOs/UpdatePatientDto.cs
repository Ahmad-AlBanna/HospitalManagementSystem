using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Patients.DTOs;

public record UpdatePatientDto
(
    [Required]
    [StringLength(100)]
    string FirstName,

    [Required]
    [StringLength(100)]
    string LastName,

    [Required]
    DateTime DateOfBirth,

    [Required]
    [StringLength(20)]
    string Gender,

    [Phone]
    string? PhoneNumber,

    [EmailAddress]
    string? Email,

    [StringLength(250)]
    string? Address
);