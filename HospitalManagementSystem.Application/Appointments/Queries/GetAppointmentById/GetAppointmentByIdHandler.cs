using HospitalManagementSystem.Application.Appointments.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Appointments.Queries.GetAppointmentById;

public class GetAppointmentByIdHandler
    : IRequestHandler<GetAppointmentByIdQuery, AppointmentDto?>
{
    private readonly IDapperExecutor _dapper;


    public GetAppointmentByIdHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<AppointmentDto?> Handle(
        GetAppointmentByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _dapper.QuerySingleOrDefaultAsync<AppointmentDto>(
            "dbo.Appointment_GetById",
            new
            {
                request.Id
            },
            CommandType.StoredProcedure,
            cancellationToken);
    }
}
