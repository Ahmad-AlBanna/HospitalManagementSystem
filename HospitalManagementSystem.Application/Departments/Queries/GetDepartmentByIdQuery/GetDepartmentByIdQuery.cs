using HospitalManagementSystem.Application.Departments.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Departments.Queries.GetDepartmentById;

public record GetDepartmentByIdQuery(int Id)
    : IRequest<DepartmentDto?>;
