using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Patients.Commands.DeletePatient;

public class DeletePatientHandler
    : IRequestHandler<DeletePatientCommand, bool>
{
    private readonly IDapperExecutor _dapper;

    public DeletePatientHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }


    public async Task<bool> Handle(
        DeletePatientCommand request,
        CancellationToken cancellationToken)
    {
        var rowsAffected = await _dapper.ExecuteScalarAsync<int>(
            "dbo.Patient_Delete",
            new
            {
                request.Id
            },
            CommandType.StoredProcedure,
            cancellationToken);


        return rowsAffected > 0;
    }
}
