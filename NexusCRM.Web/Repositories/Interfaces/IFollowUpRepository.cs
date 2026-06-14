using NexusCRM.Web.Entities;

namespace NexusCRM.Web.Repositories.Interfaces;

public interface IFollowUpRepository
{
    // ---------------- CRM FILTERS ----------------

    Task<List<FollowUp>> GetByDealIdAsync(int dealId);

    Task<List<FollowUp>> GetByUserIdAsync(string userId);

    Task<List<FollowUp>> GetByTaskIdAsync(int taskId);

    Task<List<FollowUp>> GetPendingAsync();

    Task<List<FollowUp>> GetCompletedAsync();

    // ---------------- DETAILS ----------------

    Task<FollowUp?> GetWithDetailsAsync(int id);

    Task<List<FollowUp>> GetWithDealAsync(int dealId);

    Task<List<FollowUp>> GetWithUserAsync(string userId);

    // ---------------- BUSINESS ACTIONS ----------------

    Task MarkAsCompletedAsync(int id);

    Task MarkAsPendingAsync(int id);

    Task CompleteAllForDealAsync(int dealId);

    // ---------------- VALIDATION ----------------

    Task<bool> ExistsByIdAsync(int id);

    // ---------------- DASHBOARD / ANALYTICS ----------------

    Task<int> GetCompletedCountByUserAsync(string userId);

    Task<int> GetPendingCountByUserAsync(string userId);

    Task<int> GetTotalByDealAsync(int dealId);
}
