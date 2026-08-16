using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Appointments.Commands.UpdateAppointmentByDoctor;

public class UpdateAppointmentByDoctorHandler
    : IRequestHandler<UpdateAppointmentByDoctorCommand, bool>
{
    private readonly IDapperExecutor _dapper;


    public UpdateAppointmentByDoctorHandler(
        IDapperExecutor dapper)
    {
        _dapper = dapper;
    }



    public async Task<bool> Handle(
        UpdateAppointmentByDoctorCommand request,
        CancellationToken cancellationToken)
    {
        var rowsAffected = await _dapper.ExecuteScalarAsync<int>(
            "sp_UpdateAppointmentByDoctor",
            new
            {
                request.Id,
                request.DoctorId,
                request.Dto.Status,
                request.Dto.Notes
            },
            CommandType.StoredProcedure,
            cancellationToken);


        return rowsAffected > 0;
    }
}
