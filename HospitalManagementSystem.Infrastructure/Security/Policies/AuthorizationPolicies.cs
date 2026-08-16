using HospitalManagementSystem.Domain.Constants;

namespace HospitalManagementSystem.Infrastructure.Security.Policies;

public static class AuthorizationPolicies // i add the policy for the A01:2025 - Broken Access Control --> its the best approach for it
{
    public const string AdminOnly = "AdminOnly";

    public const string DoctorOnly = "DoctorOnly";

    public const string AdminOrDoctor = "AdminOrDoctor";

}