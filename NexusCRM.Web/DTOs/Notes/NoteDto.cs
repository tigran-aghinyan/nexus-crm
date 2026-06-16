namespace NexusCRM.Web.DTOs.Notes;

public class NoteDto
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public DateOnly CreatedAt { get; set; }
}
