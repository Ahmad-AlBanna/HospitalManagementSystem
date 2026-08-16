using HospitalManagementSystem.Application.Departments.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Departments.Commands.UpdateDepartment;

public record UpdateDepartmentCommand(
    int Id,
    UpdateDepartmentDto Department
) : IRequest<bool>;