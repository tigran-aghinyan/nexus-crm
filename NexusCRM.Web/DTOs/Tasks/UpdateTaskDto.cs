using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Tasks;

public class UpdateTaskDto
{
    [Required] public string Description { get; set; } = null!;
    [Required] public bool IsCompleted { get; set; }
    [Required] public int DealId { get; set; }
}