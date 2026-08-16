using HospitalManagementSystem.Application.Doctors.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Doctors.Queries.GetDoctorByUserId;

public class GetDoctorByUserIdHandler
    : IRequestHandler<GetDoctorByUserIdQuery, DoctorDto?>
{
    private readonly IDapperExecutor _dapper;


    public GetDoctorByUserIdHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }


    public async Task<DoctorDto?> Handle(
        GetDoctorByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _dapper.QuerySingleOrDefaultAsync<DoctorDto>(
            "dbo.Doctor_GetByUserId",
            new
            {
                request.UserId
            },
            CommandType.StoredProcedure,
            cancellationToken);
    }
}
