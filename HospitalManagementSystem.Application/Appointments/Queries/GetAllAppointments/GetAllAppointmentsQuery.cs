using HospitalManagementSystem.Application.Appointments.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Appointments.Queries.GetAllAppointments;

public record GetAllAppointmentsQuery
    : IRequest<IEnumerable<AppointmentDto>>;
