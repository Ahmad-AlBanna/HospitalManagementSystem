using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Patients.DTOs;
using MediatR;
using System.Data;


namespace HospitalManagementSystem.Application.Patients.Queries.GetPatientHistory;


public class GetPatientHistoryHandler
    : IRequestHandler<GetPatientHistoryQuery, List<PatientHistoryDto>>
{

    private readonly IDapperExecutor _dapper;


    public GetPatientHistoryHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<List<PatientHistoryDto>> Handle(
        GetPatientHistoryQuery request,
        CancellationToken cancellationToken)
    {


        var result =
            await _dapper.QueryAsync<PatientHistoryDto>(
                "dbo.Patient_GetHistory",
                new
                {
                    request.PatientId
                },
                CommandType.StoredProcedure,
                cancellationToken);



        return result.ToList();

    }

}