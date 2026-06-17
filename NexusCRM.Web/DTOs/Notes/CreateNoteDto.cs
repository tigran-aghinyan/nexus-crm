using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Notes;

public class CreateNoteDto
{
    [MaxLength(1000)] [Required] public string Content { get; set; } = null!;
}
