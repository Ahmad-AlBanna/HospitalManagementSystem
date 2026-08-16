using HospitalManagementSystem.Application.Appointments.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Appointments.Queries.GetDoctorAppointments;


public class GetDoctorAppointmentsQuery
    : IRequest<List<AppointmentDto>>
{

    public int UserId { get; }


    public GetDoctorAppointmentsQuery(int userId)
    {
        UserId = userId;
    }

}