using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Patients.DTOs;

public record PatientDto
{
    public int Id { get; init; }

    public int UserId { get; init; }


    [Required]
    [MaxLength(100)]
    public string FirstName { get; init; } = string.Empty;


    [Required]
    [MaxLength(100)]
    public string LastName { get; init; } = string.Empty;


    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; init; }


    [Required]
    [MaxLength(20)]
    public string Gender { get; init; } = string.Empty;


    [Phone]
    [MaxLength(20)]
    public string? PhoneNumber { get; init; }


    [EmailAddress]
    [MaxLength(255)]
    public string? Email { get; init; }


    [MaxLength(500)]
    public string? Address { get; init; }


    public DateTime CreatedAt { get; init; }
}