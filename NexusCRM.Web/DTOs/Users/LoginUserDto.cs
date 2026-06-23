using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Users;

public class LoginUserDto
{
    [Required]
    public string Identifier { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}
