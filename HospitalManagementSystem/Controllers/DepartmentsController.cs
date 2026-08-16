using HospitalManagementSystem.Application.Departments.Commands.CreateDepartment;
using HospitalManagementSystem.Application.Departments.Commands.DeleteDepartment;
using HospitalManagementSystem.Application.Departments.Commands.UpdateDepartment;
using HospitalManagementSystem.Application.Departments.DTOs;
using HospitalManagementSystem.Application.Departments.Queries.GetAllDepartments;
using HospitalManagementSystem.Application.Departments.Queries.GetDepartmentById;
using HospitalManagementSystem.Infrastructure.Security.Policies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DepartmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    // POST: api/departments
    [HttpPost]
    [Authorize(Policy = AuthorizationPolicies.AdminOnly)]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDto dto)

    {
        var departmentId = await _mediator.Send(new CreateDepartmentCommand(dto));

        return Ok(new
        {
            Message = "Department created successfully",
            DepartmentId = departmentId
        });
    }


    // GET: api/departments
    [HttpGet]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> GetAllDepartments()
    {
        var departments = await _mediator.Send(new GetAllDepartmentsQuery());

        return Ok(departments);
    }


    // GET: api/departments/{id}
    [HttpGet("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
        var department = await _mediator.Send(new GetDepartmentByIdQuery(id));

        if (department is null)
        {
            return NotFound(new
            {
                Message = "Department not found"
            });
        }

        return Ok(department);
    }


    // PUT: api/departments/{id}
    [HttpPut("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> UpdateDepartment(int id,[FromBody] UpdateDepartmentDto dto)
    {
        var updated = await _mediator.Send(new UpdateDepartmentCommand(id, dto));

        if (!updated)
        {
            return NotFound(new
            {
                Message = "Department not found"
            });
        }

        return Ok(new
        {
            Message = "Department updated successfully"
        });
    }


    // DELETE: api/departments/{id}
    [HttpDelete("{id:int}")]
    [Authorize(Policy = AuthorizationPolicies.AdminOrDoctor)]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var deleted = await _mediator.Send(new DeleteDepartmentCommand(id));

        if (!deleted)
        {
            return NotFound(new
            {
                Message = "Department not found"
            });
        }

        return Ok(new
        {
            Message = "Department deleted successfully",
            DepartmentId = id
        });
    }
}
