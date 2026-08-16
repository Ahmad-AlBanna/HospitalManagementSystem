using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Doctors.DTOs;

public record CreateDoctorDto
{
    public string Username { get; set; } = null!;


    [Required]
    public string PasswordHash { get; set; } = null!;


    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;


    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;


    [Required]
    [StringLength(100)]
    public string Specialization { get; set; } = string.Empty;


    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Department ID must be greater than 0.")]
    public int DepartmentId { get; set; }


    [Phone]
    public string? PhoneNumber { get; set; }


    [EmailAddress]
    public string? Email { get; set; }


    [StringLength(250)]
    public string? Address { get; set; }
}