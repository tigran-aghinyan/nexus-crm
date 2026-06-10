using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.Entities
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string? Industry { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Address { get; set; }

        public bool isActive { get; set; } = true;

        [Required]
        public DateOnly FoundedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public ICollection<Customer>? Customers { get; set; } = new List<Customer>();

        public ICollection<Customer>? Deals { get; set; } = new List<Customer>();
    }
}
