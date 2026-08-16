using HospitalManagementSystem.Application.Interfaces;
using MediatR;
using System.Data;

namespace HospitalManagementSystem.Application.Users.Commands.AddUser;

public class AddUserCommandHandler
    : IRequestHandler<AddUserCommand, int>
{
    private readonly IDapperExecutor _dapper;
    private readonly IPasswordHasher _passwordHasher;


    public AddUserCommandHandler(
        IDapperExecutor dapper,
        IPasswordHasher passwordHasher)
    {
        _dapper = dapper;
        _passwordHasher = passwordHasher;
    }



    public async Task<int> Handle(
        AddUserCommand request,
        CancellationToken cancellationToken)
    {
        var passwordHash =
            _passwordHasher.Hash(request.Password);


        return await _dapper.ExecuteScalarAsync<int>(
            "dbo.User_Create",
            new
            {
                request.Username,
                request.Email,
                PasswordHash = passwordHash,
                request.RoleId
            },
            CommandType.StoredProcedure,
            cancellationToken);
    }
}
