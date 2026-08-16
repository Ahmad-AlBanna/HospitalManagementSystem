using MediatR;

namespace HospitalManagementSystem.Application.Appointments.Commands.DeleteAppointment;

public record DeleteAppointmentCommand(int Id)
    : IRequest<bool>;