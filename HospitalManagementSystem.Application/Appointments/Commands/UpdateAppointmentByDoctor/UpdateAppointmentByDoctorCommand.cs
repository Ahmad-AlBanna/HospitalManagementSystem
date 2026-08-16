using HospitalManagementSystem.Application.Appointments.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Appointments.Commands.UpdateAppointmentByDoctor;

public record UpdateAppointmentByDoctorCommand(
    int Id,
    UpdateAppointmentByDoctorDto Dto,
    int DoctorId
) : IRequest<bool>;