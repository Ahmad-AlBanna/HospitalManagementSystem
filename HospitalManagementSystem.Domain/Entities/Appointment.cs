namespace HospitalManagementSystem.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }

    public static int PatientId { get; set; }

    public int DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}