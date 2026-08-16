using HospitalManagementSystem.Application.Patients.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Patients.Queries.SearchPatients;

public record SearchPatientsQuery(
    string SearchTerm
) : IRequest<IEnumerable<PatientDto>>;
