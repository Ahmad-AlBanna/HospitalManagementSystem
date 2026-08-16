public class Doctor
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int DepartmentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateTime CreatedAt { get; set; }
}