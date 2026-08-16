using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Departments.DTOs;

public record UpdateDepartmentDto
{
    [Required]
    [StringLength(100)]
    public string DepartmentName { get; set; } = string.Empty;

}