using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Departments.DTOs;

public record DepartmentDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

   // [StringLength(500)]
    // public string? Description { get; set; }
}