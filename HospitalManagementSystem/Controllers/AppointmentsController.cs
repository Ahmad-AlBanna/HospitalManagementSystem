using HospitalManagementSystem.Application.Appointments.Commands.BookAppointment;
using HospitalManagementSystem.Application.Appointments.Commands.DeleteAppointment;
using HospitalManagementSystem.Application.Appointments.Commands.UpdateAppointment;
using HospitalManagementSystem.Application.Appointments.Commands.UpdateAppointmentByDoctor;
using HospitalManagementSystem.Application.Appointments.DTOs;
using HospitalManagementSystem.Application.Appointments.Queries.GetAllAppointments;
using HospitalManagementSystem.Application.Appointments.Queries.GetAppointmentById;
using HospitalManagementSystem.Application.Appointments.Queries.GetDoctorAppointments;
using HospitalManagementSystem.Infrastructure.Security.Policies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AppointmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    [Authorize(Policy = AuthorizationPolicies.AdminOnly)]
    public async Task<IActionResult> CreateAppointment(
        [FromBody] AppointmentDto dto)
    {
        var userId =
            User.FindFirst("UserId")?.Value;


        if (string.IsNullOrEmpty(userId))
            return Unauthorized();


        var id =
            await _mediator.Send(
                new BookAppointmentCommand(
                    dto.PatientId,
                    dto.DoctorId,
                    dto.AppointmentDate,
                    dto.Notes,
                    int.Parse(userId)
                ));


        return Ok(new
        {
            Message = "Appointment created successfully",
            AppointmentId = id
        });
    }



    [HttpGet]
    [Authorize(Policy = AuthorizationPolicies.AdminOnly)]
    public async Task<IActionResult> GetAllAppointments()
    {
        return Ok(
            await _mediator.Send(
                new GetAllAppointmentsQuery()));
    }



    [HttpGet("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> GetById(int id)
    {
        var appointment =
            await _mediator.Send(
                new GetAppointmentByIdQuery(id));


        if (appointment is null)
            return NotFound();


        return Ok(appointment);
    }



    [HttpPut("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOnly)]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateAppointmentDto dto)
    {
        var userId =
            User.FindFirst("UserId")?.Value;


        if (string.IsNullOrEmpty(userId))
            return Unauthorized();


        var result =
            await _mediator.Send(
                new UpdateAppointmentCommand(
                    id,
                    dto,
                    int.Parse(userId)
                ));


        if (!result)
            return NotFound();


        return Ok(new
        {
            Message = "Appointment updated successfully"
        });
    }



    [HttpPut("{id:int}/doctor-update")]
    [Authorize(Policy = AuthorizationPolicies.DoctorOnly)]
    public async Task<IActionResult> UpdateStatus(
        int id,
        [FromBody] UpdateAppointmentByDoctorDto dto)
    {
        var doctorId =
            User.FindFirst("UserId")?.Value;


        if (string.IsNullOrEmpty(doctorId))
            return Unauthorized();


        var result =
            await _mediator.Send(
                new UpdateAppointmentByDoctorCommand(
                    id,
                    dto,
                    int.Parse(doctorId)
                ));


        if (!result)
            return NotFound();


        return Ok(new
        {
            Message = "Appointment updated successfully"
        });
    }



    [HttpDelete("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOnly)]
    public async Task<IActionResult> Delete(int id)
    {
        var userId =
            User.FindFirst("UserId")?.Value;


        if (string.IsNullOrEmpty(userId))
            return Unauthorized();


        var result =
            await _mediator.Send(
                new DeleteAppointmentCommand(
                    id
                ));


        if (!result)
            return NotFound();


        return Ok(new
        {
            Message = "Appointment deleted successfully"
        });
    }



    [HttpGet("my")]
    [Authorize(Policy = AuthorizationPolicies.DoctorOnly)]
    public async Task<IActionResult> GetMyAppointments()
        {
        var userId =
            User.FindFirst("UserId")?.Value;


        if (string.IsNullOrEmpty(userId))
            return Unauthorized();


        var appointments =
            await _mediator.Send(
                new GetDoctorAppointmentsQuery(
                    int.Parse(userId)
                ));


        return Ok(appointments);
    }
}