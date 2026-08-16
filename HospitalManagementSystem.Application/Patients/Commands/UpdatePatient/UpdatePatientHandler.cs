using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Patients.Commands.UpdatePatient;

public class UpdatePatientHandler
    : IRequestHandler<UpdatePatientCommand, bool>
{
    private readonly IDapperExecutor _dapper;

    public UpdatePatientHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }


    public async Task<bool> Handle(
        UpdatePatientCommand request,
        CancellationToken cancellationToken)
    {
        var rowsAffected = await _dapper.ExecuteScalarAsync<int>(
            "dbo.Patient_Update",
            new
            {
                request.Id,
                request.Patient.FirstName,
                request.Patient.LastName,
                request.Patient.DateOfBirth,
                request.Patient.Gender,
                request.Patient.PhoneNumber,
                request.Patient.Email,
                request.Patient.Address
            },
            CommandType.StoredProcedure,
            cancellationToken);


        return rowsAffected > 0;
    }
}
