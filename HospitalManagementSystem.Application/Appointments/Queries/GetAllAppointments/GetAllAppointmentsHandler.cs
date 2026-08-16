using HospitalManagementSystem.Application.Appointments.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Appointments.Queries.GetAllAppointments;

public class GetAllAppointmentsHandler
    : IRequestHandler<GetAllAppointmentsQuery, IEnumerable<AppointmentDto>>
{
    private readonly IDapperExecutor _dapper;


    public GetAllAppointmentsHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<IEnumerable<AppointmentDto>> Handle(
        GetAllAppointmentsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dapper.QueryAsync<AppointmentDto>(
            "dbo.Appointment_GetAll",
            commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken);
    }
}
