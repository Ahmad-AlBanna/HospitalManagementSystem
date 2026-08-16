using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Patients.DTOs;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Patients.Queries.GetAllPatients;

public class GetAllPatientsHandler
    : IRequestHandler<GetAllPatientsQuery, IEnumerable<PatientDto>>
{
    private readonly IDapperExecutor _dapper;

    public GetAllPatientsHandler(IDapperExecutor dapper)
    {
        _dapper = dapper;
    }

    public async Task<IEnumerable<PatientDto>> Handle(
        GetAllPatientsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dapper.QueryAsync<PatientDto>(
            "dbo.Patient_GetAll",
            commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken);
    }
}
