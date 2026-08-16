using MediatR;

namespace HospitalManagementSystem.Application.Departments.Commands.DeleteDepartment;

public record DeleteDepartmentCommand(int Id) : IRequest<bool>;