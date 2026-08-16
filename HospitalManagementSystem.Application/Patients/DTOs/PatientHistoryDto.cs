namespace HospitalManagementSystem.Application.Patients.DTOs;

public record PatientHistoryDto
{
    public int AppointmentId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; }

    public string Notes { get; set; }


    public string DoctorName { get; set; }


    public string PatientName { get; set; }
}