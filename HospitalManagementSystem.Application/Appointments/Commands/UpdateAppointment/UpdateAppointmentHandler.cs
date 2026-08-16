using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Data;

namespace HospitalManagementSystem.Application.Appointments.Commands.UpdateAppointment;

public class UpdateAppointmentHandler
    : IRequestHandler<UpdateAppointmentCommand, bool>
{
    private readonly IDapperExecutor _dapper;
    private readonly ILogger<UpdateAppointmentHandler> _logger;


    public UpdateAppointmentHandler(
      IDapperExecutor dapper,
      ILogger<UpdateAppointmentHandler> logger)
    {
        _dapper = dapper;
        _logger = logger;
    }



    public async Task<bool> Handle(
        UpdateAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var rowsAffected = await _dapper.ExecuteScalarAsync<int>(
            "dbo.Appointment_Update",
            new
            {
                request.Id,

                request.Appointment.PatientId,
                request.Appointment.DoctorId,

                request.Appointment.AppointmentDate,

                request.Appointment.Status,

                request.Appointment.Notes
            },
            CommandType.StoredProcedure,
            cancellationToken);


        if (rowsAffected > 0)
        {
            _logger.LogInformation(
                "User {UserId} updated appointment {AppointmentId}.",
                request.UserId,
                request.Id);

            return true;
        }


        return false;
    }
}
