using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Notes;

public class UpdateNoteDto
{
    [Required] [MaxLength(1000)] public string Content { get; set; } = null!;
}
