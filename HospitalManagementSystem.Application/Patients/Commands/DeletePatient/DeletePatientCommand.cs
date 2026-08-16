using MediatR;

namespace HospitalManagementSystem.Application.Patients.Commands.DeletePatient;

public record DeletePatientCommand(int Id) : IRequest<bool>;