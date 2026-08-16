using HospitalManagementSystem.Application.Doctors.Commands.CreateDoctor;
using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

public class CreateDoctorCommandHandler
    : IRequestHandler<CreateDoctorCommand, int>
{
    private readonly IDapperExecutor _dapper;
    private readonly IPasswordHasher _passwordHasher;


    public CreateDoctorCommandHandler(
        IDapperExecutor dapper,
        IPasswordHasher passwordHasher)
    {
        _dapper = dapper;
        _passwordHasher = passwordHasher;
    }



    public async Task<int> Handle(
        CreateDoctorCommand request,
        CancellationToken cancellationToken)
    {
        request.Doctor.PasswordHash =
            _passwordHasher.Hash(request.Doctor.PasswordHash);


        return await _dapper.ExecuteScalarAsync<int>(
            "dbo.CreateDoctor",
            new
            {
                request.Doctor.Username,
                request.Doctor.Email,
                request.Doctor.PasswordHash,

                request.Doctor.FirstName,
                request.Doctor.LastName,
                request.Doctor.Specialization,

                request.Doctor.DepartmentId,
                request.Doctor.PhoneNumber,
                request.Doctor.Address
            },
            CommandType.StoredProcedure,
            cancellationToken);
    }
}
