using HospitalManagementSystem.Application.Admin.Queries.GetDashboardStatistics;
using HospitalManagementSystem.Infrastructure.Security.Policies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HospitalManagementSystem.API.Controllers;


[ApiController]
[Route("api/admin")]
[Authorize(Policy = AuthorizationPolicies.AdminOnly)]
public class AdminController : ControllerBase
{

    private readonly IMediator _mediator;


    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }



    [HttpGet("dashboard")]
    public async Task<IActionResult> Dashboard()
    {

        var result =
            await _mediator.Send(
                new GetDashboardStatisticsQuery());


        return Ok(result);

    }

}