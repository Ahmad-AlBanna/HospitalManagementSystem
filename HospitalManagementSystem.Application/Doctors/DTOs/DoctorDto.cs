using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Doctors.DTOs;

public record DoctorDto
{
    public int Id { get; init; }

    public int? UserId { get; init; }


    [Range(1, int.MaxValue)]
    public int DepartmentId { get; init; }


    [MaxLength(100)]
    public string FirstName { get; init; } = string.Empty;


    [MaxLength(100)]
    public string LastName { get; init; } = string.Empty;


    [MaxLength(150)]
    public string Specialization { get; init; } = string.Empty;


    [Phone]
    [MaxLength(20)]
    public string? PhoneNumber { get; init; }


    [EmailAddress]
    [MaxLength(255)]
    public string? Email { get; init; }


    [MaxLength(500)]
    public string? Address { get; init; }


    public DateTime CreatedAt { get; init; }


    [MaxLength(100)]
    public string? DepartmentName { get; set; }
}