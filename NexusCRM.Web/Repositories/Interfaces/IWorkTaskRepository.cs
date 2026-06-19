using NexusCRM.Web.Entities;

namespace NexusCRM.Web.Repositories.Interfaces;

public interface IWorkTaskRepository : IRepository<WorkTask>
{
    // ---------------- FILTERS ----------------

    Task<List<WorkTask>> GetByUserIdAsync(string userId);

    Task<List<WorkTask>> GetByDealIdAsync(int dealId);

    Task<List<WorkTask>> GetCompletedAsync();

    Task<List<WorkTask>> GetPendingAsync();

    Task<List<WorkTask>> GetOverdueAsync();

    // ---------------- DETAILS ----------------

    Task<WorkTask?> GetWithDetailsAsync(int id);

    Task<List<WorkTask>> GetWithUserAsync(string userId);

    Task<List<WorkTask>> GetWithDealAsync(int dealId);

    // ---------------- BUSINESS ACTIONS ----------------
    // TODO: IMPLEMENTATIONS MUST BE IN SERVICE LAYER
    /*Task MarkAsCompletedAsync(int id);

    Task MarkAsPendingAsync(int id);

    Task AssignToUserAsync(int taskId, int userId);

    Task ChangeDeadlineAsync(int taskId, DateTime deadline);*/

    // ---------------- VALIDATION ----------------

    Task<bool> ExistsByIdAsync(int id);

    // ---------------- DASHBOARD / ANALYTICS ----------------

    Task<int> GetCompletedCountByUserAsync(string userId);

    Task<int> GetPendingCountByUserAsync(string userId);

    Task<int> GetOverdueCountByUserAsync(string userId);
}
