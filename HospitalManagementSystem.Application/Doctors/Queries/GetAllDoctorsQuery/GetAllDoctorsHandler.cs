using HospitalManagementSystem.Application.Doctors.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Doctors.Queries.GetAllDoctors;

public class GetAllDoctorsHandler
    : IRequestHandler<GetAllDoctorsQuery, IEnumerable<DoctorDto>>
{
    private readonly IDapperExecutor _dapper;


    public GetAllDoctorsHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }


    public async Task<IEnumerable<DoctorDto>> Handle(
        GetAllDoctorsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dapper.QueryAsync<DoctorDto>(
             "dbo.Doctor_GetAll",
         commandType: CommandType.StoredProcedure,
         cancellationToken: cancellationToken);

    }
}
