using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Deals;

public class UpdateDealDto
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    public decimal EstimatedValue { get; set; }

    public DateTime? Deadline { get; set; }
}
