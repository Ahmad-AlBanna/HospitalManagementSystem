using HospitalManagementSystem.Application.Admin.DTOs;
using MediatR;

namespace HospitalManagementSystem.Application.Admin.Queries.GetDashboardStatistics;


public record GetDashboardStatisticsQuery
    : IRequest<DashboardStatisticsDto>;



