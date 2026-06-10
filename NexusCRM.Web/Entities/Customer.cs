using NexusCRM.Web.Entities.Enums;

namespace NexusCRM.Web.Entities;

public class Customer
{
    public int Id { get; set; }
    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    //TODO: to be continued | public string? Address { get; set; }

    public CustomerStatus Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public List<Deal>? Deals { get; set; }
}
