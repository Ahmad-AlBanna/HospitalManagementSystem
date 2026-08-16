using HospitalManagementSystem.Application.Doctors.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Doctors.Queries.GetDoctorById;

public record GetDoctorByIdQuery(int Id)
    : IRequest<DoctorDto?>;
