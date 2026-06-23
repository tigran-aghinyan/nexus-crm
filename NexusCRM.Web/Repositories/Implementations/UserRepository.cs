using Microsoft.EntityFrameworkCore;
using NexusCRM.Web.Data;
using NexusCRM.Web.Entities;
using NexusCRM.Web.Entities.Enums;
using NexusCRM.Web.Repositories.Interfaces;
namespace NexusCRM.Web.Repositories.Implementations;

public class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddAsync(User entity)
        => await _context.Users.AddAsync(entity);

    public async Task Delete(User entity)
        => _context.Users.Remove(entity);

    public async Task<bool> ExistsByEmailAsync(string email)
        => await _context.Users.AnyAsync(u => u.Email == email);

    public async Task<bool> ExistsByPhoneNumberAsync(string phoneNumber)
        => await _context.Users.AnyAsync(u => u.PhoneNumber == phoneNumber);

    public async Task<bool> ExistsByUserNameAsync(string userName)
        => await _context.Users.AnyAsync(u => u.UserName == userName);

    public async Task<List<User>> GetAllAsync()
        => await _context.Users.ToListAsync();

    public async Task<List<User>> GetByCompanyIdAsync(int companyId)
        => await _context.Users.Where(u => u.CompanyId == companyId).ToListAsync();

    public async Task<User?> GetByEmailAsync(string email)
        => await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

    public async Task<User?> GetByIdAsync(int id)
        => await _context.Users.FindAsync(id);

    public async Task<User?> GetByIdAsync(string id)
        => await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

    public async Task<User?> GetByPhoneNumberAsync(string phoneNumber)
        => await _context.Users.SingleOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

    public async Task<List<User>> GetByRoleAsync(UserRole role)
        => await _context.Users.Where(u => u.Role == role).ToListAsync();

    public async Task<List<User>> GetByUserNameAsync(string userName)
        => await _context.Users.Where(u => u.UserName == userName).ToListAsync();

    public async Task<User?> GetWithDetailsAsync(string id)
        => await _context.Users.Include(u => u.Company).FirstOrDefaultAsync(u => u.Id == id);

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();

    public void Update(User entity)
        => _context.Update(entity);
    public async Task<User?> GetByIdentifierAsync(string identifier)
        => await _context.Users
            .SingleOrDefaultAsync(u => u.Email == identifier || u.PhoneNumber == identifier);
}
