namespace NexusCRM.Web.DTOs.FollowUps;

public class FollowUpDto
{
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public bool isCompleted { get; set; }
}
