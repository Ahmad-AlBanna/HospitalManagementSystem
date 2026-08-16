using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Appointments.DTOs;

public record UpdateAppointmentByDoctorDto
(
    [Required]
    [StringLength(50)]
    string Status,

    [StringLength(500)]
    string? Notes
);
