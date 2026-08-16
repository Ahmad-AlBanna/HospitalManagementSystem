using HospitalManagementSystem.Application.Departments.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Departments.Queries.GetDepartmentById;

public class GetDepartmentByIdHandler
    : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto?>
{
    private readonly IDapperExecutor _dapper;


    public GetDepartmentByIdHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<DepartmentDto?> Handle(
        GetDepartmentByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _dapper.QuerySingleOrDefaultAsync<DepartmentDto>(
            "dbo.Department_GetById",
            new
            {
                request.Id
            },
            CommandType.StoredProcedure,
            cancellationToken);
    }
}
