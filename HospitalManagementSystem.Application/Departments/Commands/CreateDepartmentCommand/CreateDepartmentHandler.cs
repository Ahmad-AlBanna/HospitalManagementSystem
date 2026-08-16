using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Departments.Commands.CreateDepartment;

public class CreateDepartmentHandler
    : IRequestHandler<CreateDepartmentCommand, int>
{
    private readonly IDapperExecutor _dapper;


    public CreateDepartmentHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<int> Handle(
        CreateDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        return await _dapper.ExecuteScalarAsync<int>(
            "dbo.Department_Create",
            new
            {
                DepartmentName = request.Department.Name
            },
            CommandType.StoredProcedure,
            cancellationToken);
    }
}
