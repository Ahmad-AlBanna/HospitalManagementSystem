using Dapper;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Patients.DTOs;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Patients.Queries.GetPatientById;

public class GetPatientByIdHandler
    : IRequestHandler<GetPatientByIdQuery, PatientDto?>
{
    private readonly IDapperExecutor _dapper;

    public GetPatientByIdHandler(IDapperExecutor dapper)
    {
        _dapper = dapper;
    }

    public async Task<PatientDto?> Handle(  
        GetPatientByIdQuery request,
        CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();

        parameters.Add("@Id", request.Id);

        return await _dapper.QuerySingleOrDefaultAsync<PatientDto>(
            "dbo.Patient_GetById",
            parameters,
            CommandType.StoredProcedure,
            cancellationToken);
    }
}
