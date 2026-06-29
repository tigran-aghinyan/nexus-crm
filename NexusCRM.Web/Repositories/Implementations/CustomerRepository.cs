using Microsoft.EntityFrameworkCore;
using NexusCRM.Web.Data;
using NexusCRM.Web.Entities;
using NexusCRM.Web.Entities.Enums;
using NexusCRM.Web.Repositories.Interfaces;

namespace NexusCRM.Web.Repositories.Implementations;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
        => _context = context;

    public async Task AddAsync(Customer entity)
        => await _context.Customers.AddAsync(entity);

    public async Task Delete(Customer entity)
    {
        _context.Customers.Remove(entity);
    }

    public async Task<List<Customer>> GetAllAsync()
       =>await _context.Customers
            .AsNoTracking()
            .ToListAsync();

    public async Task<Customer?> GetByIdAsync(int id)
        => await _context.Customers.FindAsync(id);

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();

    public void Update(Customer entity)
        => _context.Update(entity);
    

    public async Task<List<Customer>> GetActiveAsync()
        => await _context.Customers
        .AsNoTracking()
        .Where(customer => customer.Status == CustomerStatus.Active)
        .ToListAsync();

    public async Task<List<Customer>> GetByStatusAsync(CustomerStatus status)
        => await _context.Customers
        .AsNoTracking()
        .Where(customer => customer.Status == status)
        .ToListAsync();
    
    public async Task<List<Customer>> SearchAsync(string keyword)
    {
        keyword = keyword.Trim();

        return await _context.Customers
            .AsNoTracking()
            .Where(customer => customer.FullName != null && customer.FullName.Contains(keyword))
            .ToListAsync();
    }

    public async Task<List<Customer>> GetByCompanyIdAsync(int companyId)
        => await _context.Customers
            .AsNoTracking()
            .Where(customer => customer.CompanyId == companyId)
            .ToListAsync();
    

    public async Task<Customer?> GetByEmailAsync(string email)
    {
        var query = _context.Customers.AsNoTracking();

        if(string.IsNullOrWhiteSpace(email))
        {
            return null;
        }

        email = email.Trim();

        return await query
            .FirstOrDefaultAsync(customer => customer.Email == email);
    }

    public async Task<Customer?> GetByPhoneAsync(string phone)
    {
        phone = phone.Trim();

        return await _context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(customer => customer.PhoneNumber == phone);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        email = email.Trim();

        return await _context.Customers.AnyAsync(customer => customer.Email == email);
    }

    public async Task<bool> ExistsByPhoneAsync(string phone)
    {
        phone = phone.Trim();

        return await _context.Customers.AnyAsync(customer => customer.PhoneNumber != null && customer.PhoneNumber == phone);
    }

    public async Task<Customer?> GetWithDetailsAsync(int id)
    {
        return await _context.Customers
            .AsNoTracking()
            .Include(customer => customer.Deals)
            .FirstOrDefaultAsync(customer => customer.Id == id);
    }

    public async Task<Customer?> GetWithDealsAsync(int id)
    {
        return await _context.Customers
            .AsNoTracking()
            .Include(customer => customer.Deals)
            .FirstOrDefaultAsync(customer => customer.Id == id);
    }

    public async Task<int> GetDealCountAsync(int customerId)
        => await _context.Deals
            .CountAsync(deal => deal.CustomerId == customerId);
}
