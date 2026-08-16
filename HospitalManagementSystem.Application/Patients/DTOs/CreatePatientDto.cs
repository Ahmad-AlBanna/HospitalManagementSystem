using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Patients.DTOs;

public record CreatePatientDto
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(100)]
    public string FirstName { get; init; } = string.Empty;


    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(100)]
    public string LastName { get; init; } = string.Empty;


    [Required(ErrorMessage = "Date of birth is required.")]
    public DateTime DateOfBirth { get; init; }


    [Required(ErrorMessage = "Gender is required.")]
    [RegularExpression(
        "^(Male|Female)$",
        ErrorMessage = "Gender must be Male or Female.")]
    public string Gender { get; init; } = string.Empty;


    [Phone(ErrorMessage = "Invalid phone number.")]
    public string? PhoneNumber { get; init; }


    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; init; }


    [StringLength(500)]
    public string? Address { get; init; }
}