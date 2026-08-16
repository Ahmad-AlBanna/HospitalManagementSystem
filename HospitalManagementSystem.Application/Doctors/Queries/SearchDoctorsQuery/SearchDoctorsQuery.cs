using HospitalManagementSystem.Application.Doctors.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Doctors.Queries.SearchDoctors;

public record SearchDoctorsQuery(
    string SearchTerm
) : IRequest<IEnumerable<DoctorDto>>;
