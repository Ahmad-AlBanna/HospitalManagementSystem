using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Patients.DTOs;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Patients.Queries.SearchPatients;

public class SearchPatientsHandler
    : IRequestHandler<SearchPatientsQuery, IEnumerable<PatientDto>>
{
    private readonly IDapperExecutor _dapper;

    public SearchPatientsHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }


    public async Task<IEnumerable<PatientDto>> Handle(
        SearchPatientsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dapper.QueryAsync<PatientDto>(
            "dbo.sp_SearchPatients",
            new
            {
                SearchTerm = request.SearchTerm
            },
            CommandType.StoredProcedure,
            cancellationToken);
    }
}
