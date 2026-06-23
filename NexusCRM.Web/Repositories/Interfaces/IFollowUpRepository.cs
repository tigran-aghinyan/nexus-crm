using NexusCRM.Web.Entities;

namespace NexusCRM.Web.Repositories.Interfaces;

public interface IFollowUpRepository : IRepository<FollowUp>
{
    Task<List<FollowUp>> GetByDealIdAsync(int dealId);
    Task<List<FollowUp>> GetByUserIdAsync(string userId);
    Task<List<FollowUp>> GetByTaskIdAsync(int taskId);
    Task<List<FollowUp>> GetPendingAsync();
    Task<List<FollowUp>> GetCompletedAsync();
    Task<FollowUp?> GetWithDetailsAsync(int id);
    Task<List<FollowUp>> GetWithDealAsync(int dealId);
    Task<List<FollowUp>> GetWithUserAsync(string userId);
    Task<int> GetCompletedCountByUserAsync(string userId);
    Task<int> GetPendingCountByUserAsync(string userId);
    Task<int> GetTotalByDealAsync(int dealId);

    Task MarkAsCompletedAsync(int id);
    Task MarkAsPendingAsync(int id);

    Task<bool> ExistsByIdAsync(int id);
}