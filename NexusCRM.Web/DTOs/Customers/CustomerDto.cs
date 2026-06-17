using NexusCRM.Web.Entities;
using NexusCRM.Web.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Customers;

public class CustomerDto
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public CustomerStatus Status { get; set; }

    public int CompanyId { get; set; }
}
