using NexusCRM.Web.DTOs.Customers;
using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Companies;

public class UpdateCompanyDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(30)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Phone]
    public string? Phone { get; set; }

    [Required]
    [StringLength(30)]
    public string Industry { get; set; } = null!;

    [Required]
    public AddressDto Address { get; set; } = null!;
}
