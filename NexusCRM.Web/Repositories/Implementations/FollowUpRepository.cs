using Microsoft.EntityFrameworkCore;
using NexusCRM.Web.Data;
using NexusCRM.Web.Entities;
using NexusCRM.Web.Repositories.Interfaces;

namespace NexusCRM.Web.Repositories.Implementations;

public class FollowUpRepository(AppDbContext context) : IFollowUpRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddAsync(FollowUp entity)
        => await _context.FollowUps.AddAsync(entity);

    public async Task Delete(FollowUp entity)
        => _context.FollowUps.Remove(entity);

    public async Task<bool> ExistsByIdAsync(int id)
        => await _context.FollowUps.AnyAsync(f => f.Id == id);

    public async Task<List<FollowUp>> GetAllAsync()
        =>await _context.FollowUps.ToListAsync();

    public async Task<List<FollowUp>> GetByDealIdAsync(int dealId)
        => await _context.FollowUps.Where(f => f.DealId == dealId).ToListAsync();

    public async Task<FollowUp?> GetByIdAsync(int id)
        => await _context.FollowUps.FindAsync(id);

    public async Task<List<FollowUp>> GetByTaskIdAsync(int taskId)
        => await _context.FollowUps.Where(f => f.TaskId == taskId).ToListAsync();

    public async Task<List<FollowUp>> GetByUserIdAsync(string userId)
        => await _context.FollowUps.Where(f => f.AssignedUserId == userId).ToListAsync();

    public async Task<List<FollowUp>> GetCompletedAsync()
        => await _context.FollowUps.Where(f => f.isCompleted).ToListAsync();

    public async Task<int> GetCompletedCountByUserAsync(string userId)
        => await _context.FollowUps.Where(f => f.AssignedUserId == userId && f.isCompleted).CountAsync();

    public async Task<List<FollowUp>> GetPendingAsync()
        => await _context.FollowUps.Where(f => !f.isCompleted).ToListAsync();

    public async Task<int> GetPendingCountByUserAsync(string userId)
        => await _context.FollowUps.Where(f => f.AssignedUserId == userId  && !f.isCompleted).CountAsync();

    public async Task<int> GetTotalByDealAsync(int dealId)
        => await _context.FollowUps.Where(f => f.DealId == dealId).CountAsync();

    public async Task<List<FollowUp>> GetWithDealAsync(int dealId)
        => await _context.FollowUps
        .Where(f => f.DealId == dealId)
        .Include(f => f.Deal)
        .ToListAsync();

   public async Task<FollowUp?> GetWithDetailsAsync(int id)
        => await _context.FollowUps
                .Include(f => f.Deal)
                .Include(f => f.Task)
                .Include(f => f.AssignedUser)
                .SingleOrDefaultAsync(f => f.Id == id);

    public async Task<List<FollowUp>> GetWithUserAsync(string userId)
        => await _context.FollowUps.
                  Where(f => f.AssignedUserId == userId).
                  Include(f => f.AssignedUser).
                  ToListAsync();                  

    public async Task MarkAsCompletedAsync(int id)
    {
        FollowUp? followUp = await _context.FollowUps.FindAsync(id);
        if (followUp is null)
            return;

        followUp.isCompleted = true;
    }

    public async Task MarkAsPendingAsync(int id)
    {
        var followUp = await _context.FollowUps.FindAsync(id);
        followUp?.isCompleted = false;
    }

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();

    public void Update(FollowUp entity)
        => _context.Update(entity);
}
