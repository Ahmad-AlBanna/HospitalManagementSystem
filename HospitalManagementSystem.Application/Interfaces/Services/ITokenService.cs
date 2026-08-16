using HospitalManagementSystem.Application.Users.DTOs;

public interface ITokenService
{
    string GenerateToken(UserDto user,string role);
           
}
