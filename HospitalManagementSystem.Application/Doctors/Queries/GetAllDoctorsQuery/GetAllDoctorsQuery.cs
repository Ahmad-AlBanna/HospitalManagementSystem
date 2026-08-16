using HospitalManagementSystem.Application.Doctors.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Doctors.Queries.GetAllDoctors;

public record GetAllDoctorsQuery()
    : IRequest<IEnumerable<DoctorDto>>;
