using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.FollowUps;

public class UpdateFollowUpDto
{
    [Required]
    public string Content { get; set; } = null!;
    public bool IsCompleted { get; set; }
    public int? TaskId { get; set; }
}
