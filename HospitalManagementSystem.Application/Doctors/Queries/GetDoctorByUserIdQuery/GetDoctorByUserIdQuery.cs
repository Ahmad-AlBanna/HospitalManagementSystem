using HospitalManagementSystem.Application.Doctors.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Doctors.Queries.GetDoctorByUserId;

public record GetDoctorByUserIdQuery(int UserId)
    : IRequest<DoctorDto?>;
