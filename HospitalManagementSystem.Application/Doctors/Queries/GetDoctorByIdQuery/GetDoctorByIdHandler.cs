using HospitalManagementSystem.Application.Doctors.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Doctors.Queries.GetDoctorById;

public class GetDoctorByIdHandler
    : IRequestHandler<GetDoctorByIdQuery, DoctorDto?>
{
    private readonly IDapperExecutor _dapper;

    public GetDoctorByIdHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }


    public async Task<DoctorDto?> Handle(
        GetDoctorByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _dapper.QuerySingleOrDefaultAsync<DoctorDto>(
            "dbo.Doctor_GetById",
            new
            {
                request.Id
            },
            CommandType.StoredProcedure,
            cancellationToken);
    }
}
