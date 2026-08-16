using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Appointments.DTOs;

public record AppointmentDto
{
    public int Id { get; set; }


    [Required]
    [Range(1, int.MaxValue)]
    public int PatientId { get; set; }


    [Required]
    [Range(1, int.MaxValue)]
    public int DoctorId { get; set; }


    [MaxLength(100)]
    public string? DoctorName { get; set; }


    [MaxLength(100)]
    public string? PatientName { get; set; }


    [Required]
    public DateTime AppointmentDate { get; set; }


    [Required]
    [MaxLength(50)]
    public string Status { get; set; } = string.Empty;


    [MaxLength(2000)]
    public string? Notes { get; set; }


    public DateTime CreatedAt { get; set; }
}