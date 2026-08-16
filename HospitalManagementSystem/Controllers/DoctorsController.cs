using HospitalManagementSystem.Application.Doctors.Commands.CreateDoctor;
using HospitalManagementSystem.Application.Doctors.Commands.DeleteDoctor;
using HospitalManagementSystem.Application.Doctors.Commands.UpdateDoctor;
using HospitalManagementSystem.Application.Doctors.DTOs;
using HospitalManagementSystem.Application.Doctors.Queries.GetAllDoctors;
using HospitalManagementSystem.Application.Doctors.Queries.GetDoctorById;
using HospitalManagementSystem.Application.Doctors.Queries.GetDoctorByUserId;
using HospitalManagementSystem.Application.Doctors.Queries.SearchDoctors;
using HospitalManagementSystem.Infrastructure.Security.Policies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalManagementSystem.API.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DoctorsController : ControllerBase
{
    private readonly IMediator _mediator;


    public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }



    [HttpPost]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> CreateDoctor(
        [FromBody] CreateDoctorDto dto)
    {
        var id =
            await _mediator.Send(
                new CreateDoctorCommand(dto));


        return Ok(new
        {
            Message = "Doctor created successfully",
            DoctorId = id
        });
    }



    [HttpGet]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> GetAllDoctors()
    {
        var doctors =
            await _mediator.Send(
                new GetAllDoctorsQuery());


        return Ok(doctors);
    }



    [HttpGet("me")]
    [Authorize(Policy = AuthorizationPolicies.DoctorOnly)]
    public async Task<IActionResult> GetMyProfile()
    {
        var userId =
     User.FindFirst("UserId")?.Value;


        if (string.IsNullOrEmpty(userId))
            return Unauthorized();



        var doctor =
            await _mediator.Send(
                new GetDoctorByUserIdQuery(
                    int.Parse(userId)));



        if (doctor is null)
            return NotFound();


        return Ok(doctor);
    }



    [HttpGet("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> GetDoctorById(
        int id)
    {
        var doctor =
            await _mediator.Send(
                new GetDoctorByIdQuery(id));


        if (doctor is null)
            return NotFound();


        return Ok(doctor);
    }



    [HttpGet("search")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> Search(
        string term)
    {
        var doctors =
            await _mediator.Send(
                new SearchDoctorsQuery(term));


        return Ok(doctors);
    }



    [HttpPut("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateDoctorDto dto)
    {
        var updated =
            await _mediator.Send(
                new UpdateDoctorCommand(id, dto));


        if (!updated)
            return NotFound();


        return Ok(new
        {
            Message = "Doctor updated successfully"
        });
    }



    [HttpDelete("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> Delete(
        int id)
    {
        var deleted =
            await _mediator.Send(
                new DeleteDoctorCommand(id));


        if (!deleted)
            return NotFound();


        return Ok(new
        {
            Message = "Doctor deleted successfully"
        });
    }
}
