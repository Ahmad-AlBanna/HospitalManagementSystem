using HospitalManagementSystem.Application.Departments.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Departments.Queries.GetAllDepartments;

public class GetAllDepartmentsHandler
    : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDto>>
{
    private readonly IDapperExecutor _dapper;


    public GetAllDepartmentsHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<IEnumerable<DepartmentDto>> Handle(
        GetAllDepartmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dapper.QueryAsync<DepartmentDto>(
            "dbo.Department_GetAll",
            commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken);
    }
}
