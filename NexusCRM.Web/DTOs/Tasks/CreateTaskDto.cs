using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.DTOs.Tasks;

public class CreateTaskDto
{
    [StringLength(30)]
    [Required]  
    public string Title { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required] 
    public DateTime Deadline { get; set; }
    [Required] 
    public int DealId { get; set; }
}
