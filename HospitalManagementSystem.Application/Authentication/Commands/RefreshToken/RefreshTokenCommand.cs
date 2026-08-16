using HospitalManagementSystem.Application.Authentication.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Authentication.Commands.RefreshToken;

public record RefreshTokenCommand(
    string RefreshToken
) : IRequest<LoginResponseDto>;