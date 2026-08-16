using HospitalManagementSystem.Application.Authentication.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Authentication.Commands;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<LoginResponseDto>;