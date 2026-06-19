using Microsoft.EntityFrameworkCore;
using NexusCRM.Web.Data;
using NexusCRM.Web.Entities;
using NexusCRM.Web.Repositories.Interfaces;

namespace NexusCRM.Web.Repositories.Implementations;

public class WorkTaskRepository : IWorkTaskRepository
{
    private readonly AppDbContext _context;
    public WorkTaskRepository(AppDbContext context)
        => _context = context;

    public async Task AddAsync(WorkTask entity)
        => await _context.Tasks.AddAsync(entity);

    public async Task Delete(WorkTask entity)
        => _context.Tasks.Remove(entity);

    public async Task<bool> ExistsByIdAsync(int id)
        => await _context.Tasks.AnyAsync(t => t.Id == id);

    public async Task<List<WorkTask>> GetAllAsync()
        => await _context.Tasks.ToListAsync();

    public async Task<List<WorkTask>> GetByDealIdAsync(int dealId)
        => await _context.Tasks.Where(t => t.DealId == dealId).ToListAsync();

    public async Task<WorkTask?> GetByIdAsync(int id)
        => await _context.Tasks.FindAsync(id);

    public async Task<List<WorkTask>> GetByUserIdAsync(string userId)
        => await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();

    public async Task<List<WorkTask>> GetCompletedAsync()
        => await _context.Tasks.Where(t => t.IsCompleted).ToListAsync();

    public async Task<int> GetCompletedCountByUserAsync(string userId)
        => await _context.Tasks.Where(t => t.IsCompleted).CountAsync();

    public async Task<List<WorkTask>> GetOverdueAsync()
        => await _context.Tasks.Where(t => !t.IsCompleted && DateTime.Now > t.Deadline).ToListAsync();

    public async Task<int> GetOverdueCountByUserAsync(string userId)
        => await _context.Tasks.Where(t => !t.IsCompleted && DateTime.Now > t.Deadline).CountAsync();

    public async Task<List<WorkTask>> GetPendingAsync()
        => await _context.Tasks.Where(t => !t.IsCompleted).ToListAsync();

    public async Task<int> GetPendingCountByUserAsync(string userId)
        => await _context.Tasks.Where(t => !t.IsCompleted).CountAsync();

    public async Task<List<WorkTask>> GetWithDealAsync(int dealId)
        => await _context.Tasks.Where(t => t.DealId == dealId).Include(t => t.Deal).ToListAsync();

    public async Task<WorkTask?> GetWithDetailsAsync(int id)
        => await _context.Tasks.Include(t => t.Deal).Include(t => t.User).FirstOrDefaultAsync(t =>  t.Id == id);

    public async Task<List<WorkTask>> GetWithUserAsync(string userId)
        => await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();

    public void Update(WorkTask entity)
        => _context.Update(entity);
}
