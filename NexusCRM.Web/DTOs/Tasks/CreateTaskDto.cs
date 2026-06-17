using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Tasks;

public class CreateTaskDto
{
    [Required] [StringLength(30)] public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    [Required] public DateTime Deadline { get; set; }
    [Required] public int DealId { get; set; }
}
