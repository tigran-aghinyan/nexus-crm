namespace NexusCRM.Web.DTOs.Notes;

public class DetailsNoteDto
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public DateOnly CreatedAt { get; set; }
    public string AuthorId { get; set; } = null!;
    public string? AuthorName { get; set; }
    public string? AuthorEmail { get; set; }

}
