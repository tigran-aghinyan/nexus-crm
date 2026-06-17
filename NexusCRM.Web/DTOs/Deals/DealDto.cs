using NexusCRM.Web.Entities;
using NexusCRM.Web.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Deals;

public class DealDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    public decimal EstimatedValue { get; set; }

    public DealStatus Status { get; set; }

    public int CustomerId { get; set; }

    public int? CompanyId { get; set; }

}
