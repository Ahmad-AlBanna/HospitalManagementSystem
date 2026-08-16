using HospitalManagementSystem.Application.Appointments.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Appointments.Queries.GetAppointmentById;

public record GetAppointmentByIdQuery(int Id)
    : IRequest<AppointmentDto?>;
