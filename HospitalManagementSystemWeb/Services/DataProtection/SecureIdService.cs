using Microsoft.AspNetCore.DataProtection;

namespace HospitalManagementSystemWeb.Services.DataProtection;

public class SecureIdService
{
    private readonly IDataProtector _protector;

    public SecureIdService(IDataProtectionProvider provider)
    {
        _protector = provider.CreateProtector(
            "HospitalManagementSystem.SecureIds");
    }

    public string Protect(int id)
    {
        return _protector.Protect(id.ToString());
    }

    public int Unprotect(string protectedId)
    {
        if (string.IsNullOrWhiteSpace(protectedId))
        {
            throw new ArgumentException(
                "Protected ID cannot be empty.",
                nameof(protectedId));
        }

        try
        {
            var id = _protector.Unprotect(protectedId);

            if (!int.TryParse(id, out var result))
            {
                throw new InvalidOperationException(
                    "The protected ID does not contain a valid integer.");
            }

            return result;
        }
        catch (System.Security.Cryptography.CryptographicException ex)
        {
            throw new InvalidOperationException(
                "The provided ID is invalid or has expired.",
                ex);
        }
    }
}