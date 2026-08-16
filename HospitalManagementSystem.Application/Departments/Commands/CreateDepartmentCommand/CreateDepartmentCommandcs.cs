using HospitalManagementSystem.Application.Departments.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Departments.Commands.CreateDepartment;

public record CreateDepartmentCommand(
    CreateDepartmentDto Department
) : IRequest<int>;