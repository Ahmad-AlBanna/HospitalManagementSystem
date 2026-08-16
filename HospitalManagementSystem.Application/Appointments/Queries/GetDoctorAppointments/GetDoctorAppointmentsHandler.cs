using HospitalManagementSystem.Application.Appointments.DTOs;
using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;


namespace HospitalManagementSystem.Application.Appointments.Queries.GetDoctorAppointments;


public class GetDoctorAppointmentsHandler
    : IRequestHandler<GetDoctorAppointmentsQuery, List<AppointmentDto>>
{

    private readonly IDapperExecutor _dapper;


    public GetDoctorAppointmentsHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<List<AppointmentDto>> Handle(
        GetDoctorAppointmentsQuery request,
        CancellationToken cancellationToken)
    {


        var appointments =
            await _dapper.QueryAsync<AppointmentDto>(
                "dbo.Appointment_GetByDoctorUserId",
                new
                {
                    request.UserId
                },
                CommandType.StoredProcedure,
                cancellationToken);



        return appointments.ToList();

    }

}