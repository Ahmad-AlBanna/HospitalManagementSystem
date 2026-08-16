namespace HospitalManagementSystem.Application.Admin.DTOs;

public record DashboardStatisticsDto
{
    public int Doctors { get; set; }

    public int Patients { get; set; }

    public int Departments { get; set; }

    public int Appointments { get; set; }
}