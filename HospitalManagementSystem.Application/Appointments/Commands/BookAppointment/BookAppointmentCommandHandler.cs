using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Data;

namespace HospitalManagementSystem.Application.Appointments.Commands.BookAppointment;

public class BookAppointmentCommandHandler
    : IRequestHandler<BookAppointmentCommand, int>
{
    private readonly IDapperExecutor _dapper;
    private readonly ILogger<BookAppointmentCommandHandler> _logger;


    public BookAppointmentCommandHandler(
        IDapperExecutor dapper,
        ILogger<BookAppointmentCommandHandler> logger)
    {
        _dapper = dapper;
        _logger = logger;
    }



    public async Task<int> Handle(
        BookAppointmentCommand request,
        CancellationToken cancellationToken)
    {
        var appointmentId =
    await _dapper.ExecuteScalarAsync<int>(
        "sp_BookAppointment",
        new
        {
            request.DoctorId,
            request.PatientId,
            request.AppointmentDate,
            request.Notes
        },
        CommandType.StoredProcedure,
        cancellationToken);


        _logger.LogInformation(
            "User {UserId} created appointment {AppointmentId}.",
            request.UserId,
            appointmentId);


        return appointmentId;
    }
}
