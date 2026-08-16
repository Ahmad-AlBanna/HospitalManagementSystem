using HospitalManagementSystem.Application.Patients.DTOs;
using MediatR;


namespace HospitalManagementSystem.Application.Patients.Queries.GetPatientById;


public record GetPatientByIdQuery(int Id)
    : IRequest<PatientDto?>;