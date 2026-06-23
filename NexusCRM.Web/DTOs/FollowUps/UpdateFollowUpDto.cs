using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.FollowUps;

public class UpdateFollowUpDto
{
    [StringLength(1000)]
    [Required] 
    public string Content { get; set; } = null!;
    [Required] 
    public bool IsCompleted { get; set; }
    public int? TaskId { get; set; }
}
