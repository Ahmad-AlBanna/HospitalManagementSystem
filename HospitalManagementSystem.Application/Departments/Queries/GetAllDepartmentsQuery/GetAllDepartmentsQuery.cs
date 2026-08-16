using HospitalManagementSystem.Application.Departments.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Departments.Queries.GetAllDepartments;

public record GetAllDepartmentsQuery
    : IRequest<IEnumerable<DepartmentDto>>;
