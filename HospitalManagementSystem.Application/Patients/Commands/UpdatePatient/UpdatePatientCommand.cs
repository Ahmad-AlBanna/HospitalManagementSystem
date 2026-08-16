using HospitalManagementSystem.Application.Patients.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Patients.Commands.UpdatePatient;

public record UpdatePatientCommand(
    int Id,
    UpdatePatientDto Patient) : IRequest<bool>;