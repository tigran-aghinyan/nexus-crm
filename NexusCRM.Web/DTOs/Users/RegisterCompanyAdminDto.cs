using NexusCRM.Web.Entities;

namespace NexusCRM.Web.DTOs.Users;

public class RegisterCompanyAdminDto
{
    // Company data
    public string CompanyName { get; set; } = null!;
    public string Industry { get; set; } = null!;
    public string CompanyEmail { get; set; } = null!;
    public string CompanyPhone { get; set; } = null!;

    // Admin user data
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}
