using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.FollowUps;

public class DetailsFollowUpDto
{
    public int Id { get; set; }
    [Required]
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public bool isCompleted { get; set; }
    public int DealId { get; set; }
    [Required]
    public string AssignedUserId { get; set; } = null!;
    public int? TaskId { get; set; }

}
