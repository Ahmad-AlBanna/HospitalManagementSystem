using MediatR;

namespace HospitalManagementSystem.Application.Users.Commands.AddUser;

public record AddUserCommand(
    string Username,
    string Email,
    string Password,
    int RoleId
) : IRequest<int>;