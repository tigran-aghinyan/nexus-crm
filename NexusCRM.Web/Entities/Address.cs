using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NexusCRM.Web.Entities;

[Owned]
public class Address
{
    [Required] public string? Country { get; set; }
    [Required] public string Region { get; set; } = null!;
    [Required] public string? City { get; set; }
    [Required] public string Street { get; set; } = null!;
    public string? PostalCode { get; set; }
}
