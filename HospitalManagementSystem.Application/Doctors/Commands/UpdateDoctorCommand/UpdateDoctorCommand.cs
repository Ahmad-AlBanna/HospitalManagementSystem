using HospitalManagementSystem.Application.Doctors.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Doctors.Commands.UpdateDoctor;

public record UpdateDoctorCommand(
    int Id,
    UpdateDoctorDto Doctor
) : IRequest<bool>;