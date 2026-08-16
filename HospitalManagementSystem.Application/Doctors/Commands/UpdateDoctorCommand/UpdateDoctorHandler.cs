using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Doctors.Commands.UpdateDoctor;

public class UpdateDoctorHandler
    : IRequestHandler<UpdateDoctorCommand, bool>
{
    private readonly IDapperExecutor _dapper;


    public UpdateDoctorHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<bool> Handle(
        UpdateDoctorCommand request,
        CancellationToken cancellationToken)
    {
        var rowsAffected = await _dapper.ExecuteScalarAsync<int>(
            "dbo.Doctor_Update",
            new
            {
                request.Id,

                request.Doctor.FirstName,
                request.Doctor.LastName,
                request.Doctor.Specialization,

                request.Doctor.PhoneNumber,
                request.Doctor.Email
            },
            CommandType.StoredProcedure,
            cancellationToken);



        return rowsAffected > 0;
    }
}
