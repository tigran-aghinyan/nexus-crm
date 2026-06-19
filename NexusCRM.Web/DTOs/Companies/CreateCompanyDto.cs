using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Companies;

public class CreateCompanyDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength (30)]
    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    [Required]
    public string Industry { get; set; } = null!;
}
