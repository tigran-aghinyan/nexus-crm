using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Notes;

public class UpdateNoteDto
{
    public int Id { get; set; }
    [Required]
    [MaxLength(1000)]
    public string Content { get; set; } = null!;
}
