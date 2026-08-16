using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Patients.Commands.CreatePatient;

public class CreatePatientHandler
    : IRequestHandler<CreatePatientCommand, int>
{
    private readonly IDapperExecutor _dapper;

    public CreatePatientHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }


    public async Task<int> Handle(
        CreatePatientCommand request,
        CancellationToken cancellationToken)
    {
        return await _dapper.ExecuteScalarAsync<int>(
            "dbo.sp_CreatePatient",
            new
            {
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
    }
}
