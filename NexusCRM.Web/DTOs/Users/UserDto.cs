using NexusCRM.Web.Entities.Enums;

namespace NexusCRM.Web.DTOs.Users;

public class UserDto
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public UserRole Role { get; set; }
    public DateOnly RegDate { get; set; }
}
