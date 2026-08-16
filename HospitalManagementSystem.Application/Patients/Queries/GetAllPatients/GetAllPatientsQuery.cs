using HospitalManagementSystem.Application.Patients.DTOs;
using HospitalManagementSystem.Domain.Entities;
using MediatR;

namespace HospitalManagementSystem.Application.Patients.Queries.GetAllPatients;

public record GetAllPatientsQuery()
    : IRequest<IEnumerable<PatientDto>>;