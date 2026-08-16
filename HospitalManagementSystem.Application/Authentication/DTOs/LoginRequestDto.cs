  using System.ComponentModel.DataAnnotations;

public record LoginRequestDto
(
    [Required]
    [EmailAddress]
    string Email,

    [Required]
    [MinLength(6)] // maybe later i will add change password
    string Password
);