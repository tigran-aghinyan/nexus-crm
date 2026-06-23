namespace NexusCRM.Web.DTOs.Tasks;

public class DetailsTaskDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Deadline { get; set; }
    public bool IsCompleted { get; set; }
    public string UserId { get; set; } = null!;
    public int DealId { get; set; }
}
