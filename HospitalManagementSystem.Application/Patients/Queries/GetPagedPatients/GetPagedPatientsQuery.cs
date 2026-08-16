using HospitalManagementSystem.Application.Common.Models;
using HospitalManagementSystem.Application.Patients.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Patients.Queries.GetPagedPatients;

public record GetPagedPatientsQuery(
    PaginationRequest Request)
    : IRequest<PagedResult<PatientDto>>;
