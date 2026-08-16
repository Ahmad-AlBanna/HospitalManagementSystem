using HospitalManagementSystem.Application.Doctors.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Doctors.Commands.CreateDoctor;

public record CreateDoctorCommand(
    CreateDoctorDto Doctor
) : IRequest<int>;