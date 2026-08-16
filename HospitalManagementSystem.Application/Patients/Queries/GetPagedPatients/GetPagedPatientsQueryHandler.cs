using HospitalManagementSystem.Application.Common.Models;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Patients.DTOs;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Patients.Queries.GetPagedPatients;

public class GetPagedPatientsQueryHandler
    : IRequestHandler<
        GetPagedPatientsQuery,
        PagedResult<PatientDto>>
{
    private readonly IDapperExecutor _dapper;

    public GetPagedPatientsQueryHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }


    public async Task<PagedResult<PatientDto>> Handle(
        GetPagedPatientsQuery request,
        CancellationToken cancellationToken)
    {
        var pagination = request.Request;


        var parameters = new
        {
            pagination.PageNumber,
            pagination.PageSize,
            pagination.SearchTerm,
            pagination.Gender,
            pagination.SortColumn
        };


        return await _dapper.ExecutePagedProcedureAsync<PatientDto>(
            "GetPatientsPaged",
            parameters,
            pagination.PageNumber,
            pagination.PageSize,
            cancellationToken);
    }
}
