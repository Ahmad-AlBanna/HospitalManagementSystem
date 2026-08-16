using HospitalManagementSystem.Application.Patients.DTOs;
using MediatR;


namespace HospitalManagementSystem.Application.Patients.Queries.GetPatientHistory;


public record GetPatientHistoryQuery(
    int PatientId
)
: IRequest<List<PatientHistoryDto>>;