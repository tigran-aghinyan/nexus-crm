using NexusCRM.Web.DTOs.Customers;

namespace NexusCRM.Web.DTOs.Companies;

public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Industry { get; set; }

    public bool IsActive { get; set; }

    public DateOnly FoundedDate { get; set; }

    public AddressDto? Address { get; set; }
}
