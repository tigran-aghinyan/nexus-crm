using NexusCRM.Web.Entities;
using NexusCRM.Web.Entities.Enums;

namespace NexusCRM.Web.DTOs.Customers;

public class CustomerDetailsDto
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime? Created { get; set; }

    public AddressDto Address { get; set; } = null!;

    public CustomerStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<DealSummaryDto>? Deals { get; set; }

    public int CompanyId { get; set; }
}
