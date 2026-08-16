using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Application.Appointments.DTOs;

public record UpdateAppointmentDto
(
    [Required]
    int PatientId,

    [Required]
    int DoctorId,

    [Required]
    DateTime AppointmentDate,

    [Required]
    [StringLength(50)]
    string Status,

    [StringLength(500)]
    string? Notes
);
