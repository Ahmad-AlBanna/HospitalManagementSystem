using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Application.Interfaces.Services;
using HospitalManagementSystem.Infrastructure.DataAccess;
using HospitalManagementSystem.Infrastructure.DataAccess.ConnectionFactory;

using HospitalManagementSystem.Infrastructure.Security.PasswordHasher;
using HospitalManagementSystem.Infrastructure.Security.TokenService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagementSystem.Infrastructure.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IConnectionFactory, SqlConnectionFactory>();

        services.AddScoped<IDapperExecutor, DapperExecutor> ();

        services.AddScoped<IPasswordHasher, PasswordHasher>();

        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<IRefreshTokenService, RefreshTokenService>();


        return services;
    }
}