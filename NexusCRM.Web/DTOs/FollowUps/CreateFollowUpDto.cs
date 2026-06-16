using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.FollowUps;

public class CreateFollowUpDto
{
    [Required]
    public string Content { get; set; } = null!;
    public string AssignedUserId { get; set; } = null!;
    public int DealId { get; set; }
    public int? TaskId { get; set; }
}
