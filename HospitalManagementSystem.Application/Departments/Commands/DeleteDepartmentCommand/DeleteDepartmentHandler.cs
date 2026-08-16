using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Departments.Commands.DeleteDepartment;

public class DeleteDepartmentHandler
    : IRequestHandler<DeleteDepartmentCommand, bool>
{
    private readonly IDapperExecutor _dapper;


    public DeleteDepartmentHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<bool> Handle(
        DeleteDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        var rowsAffected = await _dapper.ExecuteScalarAsync<int>(
            "dbo.Department_Delete",
            new
            {
                request.Id
            },
            CommandType.StoredProcedure,
            cancellationToken);


        return rowsAffected > 0;
    }
}
