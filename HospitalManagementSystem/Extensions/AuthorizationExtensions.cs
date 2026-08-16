using HospitalManagementSystem.Domain.Constants;
using HospitalManagementSystem.Infrastructure.Security.Policies;

namespace HospitalManagementSystem.API.Extensions;

public static class AuthorizationExtensions
{
    public static IServiceCollection AddApplicationAuthorization(
        this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(
                AuthorizationPolicies.AdminOnly,
                policy =>
                    policy.RequireRole(Roles.Admin));


            options.AddPolicy(
                AuthorizationPolicies.DoctorOnly,
                policy =>
                    policy.RequireRole(Roles.Doctor));


            options.AddPolicy(
                AuthorizationPolicies.AdminOrDoctor,
                    policy => policy.RequireRole(Roles.Admin, Roles.Doctor));
        });

        return services;
    }
}