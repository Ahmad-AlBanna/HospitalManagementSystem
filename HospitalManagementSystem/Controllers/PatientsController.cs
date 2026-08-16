using HospitalManagementSystem.Application.Common.Models;
using HospitalManagementSystem.Application.Patients.Commands.CreatePatient;
using HospitalManagementSystem.Application.Patients.Commands.DeletePatient;
using HospitalManagementSystem.Application.Patients.Commands.UpdatePatient;
using HospitalManagementSystem.Application.Patients.DTOs;
using HospitalManagementSystem.Application.Patients.Queries.GetAllPatients;
using HospitalManagementSystem.Application.Patients.Queries.GetPagedPatients;
using HospitalManagementSystem.Application.Patients.Queries.GetPatientById;
using HospitalManagementSystem.Application.Patients.Queries.GetPatientHistory;
using HospitalManagementSystem.Application.Patients.Queries.SearchPatients;
using HospitalManagementSystem.Infrastructure.Security.Policies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HospitalManagementSystem.API.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PatientsController : ControllerBase
{
    private readonly IMediator _mediator;


    public PatientsController(IMediator mediator)
    {
        _mediator = mediator;
    }



    [HttpPost]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> Create(
        [FromBody] CreatePatientDto dto)
    {
        var id =
            await _mediator.Send(
                new CreatePatientCommand(dto));


        return Ok(new
        {
            Message = "Patient created successfully",
            PatientId = id
        });
    }



    [HttpGet]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(
            await _mediator.Send(
                new GetAllPatientsQuery()));
    }



    [HttpGet("paged")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> GetPaged(
        [FromQuery] PaginationRequest request)
    {
        return Ok(
            await _mediator.Send(
                new GetPagedPatientsQuery(request)));
    }



    [HttpGet("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> GetById(
        int id)
    {
        var patient =
            await _mediator.Send(
                new GetPatientByIdQuery(id));


        if (patient is null)
            return NotFound();


        return Ok(patient);
    }



    [HttpGet("search")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> Search(           //  لسا ما ضفتهم , فكرة اضيف صفحة جديدة يكون فيها البحث عن المريض + الدكتور ؟!؟!
        string SearchTerm)
    {
        var patients =
            await _mediator.Send(
                new SearchPatientsQuery(SearchTerm));


        return Ok(patients);
    }



    [HttpPut("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOnly)]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdatePatientDto dto)
    {
        var updated =
            await _mediator.Send(
                new UpdatePatientCommand(id, dto));


        if (!updated)
            return NotFound();


        return Ok(new
        {
            Message = "Patient updated successfully"
        });
    }



    [HttpDelete("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOnly)]
    public async Task<IActionResult> Delete(
        int id)
    {
        var deleted =
            await _mediator.Send(
                new DeletePatientCommand(id));


        if (!deleted)
            return NotFound();


        return Ok(new
        {
            Message = "Patient deleted successfully"
        });
    }



    [HttpGet("{id:int}/history")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> GetHistory(
        int id)
    {

        return Ok(
            await _mediator.Send(
                new GetPatientHistoryQuery(id)));

    }

}
