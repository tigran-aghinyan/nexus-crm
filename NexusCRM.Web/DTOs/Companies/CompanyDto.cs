namespace NexusCRM.Web.DTOs.Companies;

public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public DateOnly? DateOnly { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Industry { get; set; }
}
