using HospitalManagementSystem.Application.Appointments.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Appointments.Commands.UpdateAppointment;

public record UpdateAppointmentCommand(
    int Id,
    UpdateAppointmentDto Appointment,
    int UserId
) : IRequest<bool>;