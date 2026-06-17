using NexusCRM.Web.Entities;
using NexusCRM.Web.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Deals;

public class CreateDealDto
{
    [Required]
    [MaxLength(20)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public decimal EstimatedValue { get; set; }

    public DealStatus Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public DateTime? Deadline { get; set; }

    [Range(1, int.MaxValue)]
    public int CustomerId { get; set; }

    [Range(1, int.MaxValue)]
    public int CompanyId { get; set; }
}
