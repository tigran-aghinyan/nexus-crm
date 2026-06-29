using NexusCRM.Web.Entities;
using NexusCRM.Web.Entities.Enums;

namespace NexusCRM.Web.Repositories.Interfaces;

public interface IDealRepository : IRepository<Deal>
{
    // ---------------- CRM FILTERS ----------------

    Task<List<Deal>> GetByStatusAsync(DealStatus status);

    Task<List<Deal>> GetByCustomerIdAsync(int customerId);

    Task<List<Deal>> GetByCompanyIdAsync(int companyId);

    Task<List<Deal>> GetActiveDealsAsync();

    Task<List<Deal>> GetOverdueDealsAsync();

    // ---------------- SEARCH ----------------

    Task<List<Deal>> SearchAsync(string keyword);

    // ---------------- DETAILS (IMPORTANT) ----------------

    Task<Deal?> GetWithDetailsAsync(int id);

    Task<List<Deal>> GetWithCustomerAsync(int customerId);

    Task<List<Deal>> GetWithCompanyAsync(int companyId);

    // ---------------- ANALYTICS / DASHBOARD ----------------

    Task<decimal> GetTotalEstimatedValueByCompanyAsync(int companyId);

    Task<int> GetDealCountByStatusAsync(DealStatus status);

    Task<decimal> GetTotalPipelineValueAsync();

    // ---------------- VALIDATION ----------------

    Task<bool> ExistsByTitleAsync(string title, int companyId);
}
