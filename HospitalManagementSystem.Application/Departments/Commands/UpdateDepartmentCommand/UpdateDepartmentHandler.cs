using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentHandler
    : IRequestHandler<UpdateDepartmentCommand, bool>
{
    private readonly IDapperExecutor _dapper;


    public UpdateDepartmentHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<bool> Handle(
        UpdateDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        var rowsAffected = await _dapper.ExecuteScalarAsync<int>(
            "dbo.Department_Update",
            new
            {
                request.Id,
                request.Department.DepartmentName
            },
            CommandType.StoredProcedure,
            cancellationToken);


        return rowsAffected > 0;
    }
}
