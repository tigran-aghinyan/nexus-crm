using NexusCRM.Web.Entities;
using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Customers;

public class CreateCustomerDto
{
    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [Required]
    [StringLength(30)]
    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    [Required]
    public AddressDto Address { get; set; }

    [Required]
    public int CompanyId { get; set; }
}
