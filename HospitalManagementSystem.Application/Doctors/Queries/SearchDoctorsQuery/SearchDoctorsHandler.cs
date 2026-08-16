using HospitalManagementSystem.Application.Doctors.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Doctors.Queries.SearchDoctors;

public class SearchDoctorsHandler
    : IRequestHandler<SearchDoctorsQuery, IEnumerable<DoctorDto>>
{
    private readonly IDapperExecutor _dapper;


    public SearchDoctorsHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }


    public async Task<IEnumerable<DoctorDto>> Handle(
        SearchDoctorsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dapper.QueryAsync<DoctorDto>(
            "dbo.Doctor_Search",
            new
            {
                request.SearchTerm
            },
            CommandType.StoredProcedure,
            cancellationToken);
    }
}
