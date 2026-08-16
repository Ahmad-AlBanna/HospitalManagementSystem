using HospitalManagementSystem.Application.Admin.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;


namespace HospitalManagementSystem.Application.Admin.Queries.GetDashboardStatistics;


public class GetDashboardStatisticsHandler
    : IRequestHandler<
        GetDashboardStatisticsQuery,
        DashboardStatisticsDto>
{

    private readonly IDapperExecutor _dapper;


    public GetDashboardStatisticsHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<DashboardStatisticsDto> Handle(
        GetDashboardStatisticsQuery request,
        CancellationToken cancellationToken)
    {

        return await _dapper.QuerySingleOrDefaultAsync<DashboardStatisticsDto>(
            "dbo.Dashboard_GetStatistics",
            null,
            CommandType.StoredProcedure,
            cancellationToken)
            ?? new DashboardStatisticsDto();

    }

}