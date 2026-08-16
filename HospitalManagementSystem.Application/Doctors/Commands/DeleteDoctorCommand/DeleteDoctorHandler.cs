using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Doctors.Commands.DeleteDoctor;

public class DeleteDoctorHandler
    : IRequestHandler<DeleteDoctorCommand, bool>
{
    private readonly IDapperExecutor _dapper;


    public DeleteDoctorHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<bool> Handle(
        DeleteDoctorCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _dapper.ExecuteScalarAsync<int>(
            "dbo.Doctor_Delete",
            new
            {
                request.Id
            },
            CommandType.StoredProcedure,
            cancellationToken);


        return result > 0;
    }
}
