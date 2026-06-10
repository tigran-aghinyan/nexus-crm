using Microsoft.EntityFrameworkCore;
using NexusCRM.Web.Entities;

namespace NexusCRM.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // TODO: Set<T>-ով փորձլ |
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Deal> Deals { get; set; }
    public DbSet<Company> Companies { get; set; }
}
