using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Departments.DTOs;

public record CreateDepartmentDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; init; } = string.Empty;


    [StringLength(500)]
    public string? Description { get; init; }
}