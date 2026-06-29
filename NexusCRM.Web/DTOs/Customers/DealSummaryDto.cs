using NexusCRM.Web.Entities.Enums;

namespace NexusCRM.Web.DTOs.Customers;

public class DealSummaryDto
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public decimal? EstimatedValue { get; set; }

    public DealStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? Deadline { get; set; }

    public int CustomerId { get; set; }

    public int? CompanyId { get; set; }
}
