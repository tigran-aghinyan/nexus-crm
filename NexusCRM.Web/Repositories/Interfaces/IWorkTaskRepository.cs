using NexusCRM.Web.Entities;

namespace NexusCRM.Web.Repositories.Interfaces;

public interface IWorkTaskRepository : IRepository<WorkTask>
{
    Task<List<WorkTask>> GetByUserIdAsync(string userId);
    Task<List<WorkTask>> GetByDealIdAsync(int dealId);
    Task<List<WorkTask>> GetCompletedAsync();
    Task<List<WorkTask>> GetPendingAsync();
    Task<List<WorkTask>> GetOverdueAsync();
    Task<int> GetCompletedCountByUserAsync(string userId);
    Task<int> GetPendingCountByUserAsync(string userId);
    Task<int> GetOverdueCountByUserAsync(string userId);
    Task<WorkTask?> GetWithDetailsAsync(int id);
    Task<List<WorkTask>> GetWithUserAsync(string userId);
    Task<List<WorkTask>> GetWithDealAsync(int dealId);

    Task<bool> ExistsByIdAsync(int id);
}
