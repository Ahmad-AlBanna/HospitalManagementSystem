using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Appointments.Commands.DeleteAppointment;

public class DeleteAppointmentHandler
    : IRequestHandler<DeleteAppointmentCommand, bool>
{
    private readonly IDapperExecutor _dapper;


    public DeleteAppointmentHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<bool> Handle(
        DeleteAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var rowsAffected = await _dapper.ExecuteScalarAsync<int>(
            "dbo.Appointment_Delete",
            new
            {
                request.Id
            },
            CommandType.StoredProcedure,
            cancellationToken);


        return rowsAffected > 0;
    }
}
