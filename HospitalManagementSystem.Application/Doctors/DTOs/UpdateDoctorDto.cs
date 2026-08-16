using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Doctors.DTOs;

public record UpdateDoctorDto
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; init; } = string.Empty;


    [Required]
    [StringLength(100)]
    public string LastName { get; init; } = string.Empty;


    [Required]
    [StringLength(100)]
    public string Specialization { get; init; } = string.Empty;


    [Phone]
    public string? PhoneNumber { get; init; }


    [EmailAddress]
    public string? Email { get; init; }


    [StringLength(250)]
    public string? Address { get; init; }
}