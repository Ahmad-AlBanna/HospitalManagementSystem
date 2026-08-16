using HospitalManagementSystem.Application.Patients.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Patients.Commands.CreatePatient;

public record CreatePatientCommand(
    CreatePatientDto Patient
) : IRequest<int>;