namespace NexusCRM.Web.DTOs.Customers;

public class AddressDto
{
    public string Country { get; set; } = null!;
    public string Region { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;

    public string? PostalCode { get; set; }
}
