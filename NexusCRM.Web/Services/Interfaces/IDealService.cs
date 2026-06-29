using NexusCRM.Web.DTOs.Deals;
using NexusCRM.Web.Entities.Enums;

namespace NexusCRM.Web.Services.Interfaces;

public interface IDealService
{
    Task<Result<bool>> AddAsync(CreateDealDto dto);
    Task<Result<bool>> UpdateAsync(int id, UpdateDealDto dto);
    Task<Result<bool>> DeleteAsync(int id);

    Task<Result<List<DealDto>>> GetAllAsync();
    Task<Result<DealDetailsDto>> GetByIdAsync(int id);
    Task<Result<List<DealDto>>> GetByStatusAsync(DealStatus status);
    Task<Result<List<DealDto>>> GetByCustomerIdAsync(int customerId);
    Task<Result<List<DealDto>>> GetByCompanyIdAsync(int companyId);
    Task<Result<List<DealDto>>> GetActiveDealsAsync();
    Task<Result<List<DealDto>>> GetOverdueDealsAsync();
    Task<Result<List<DealDto>>> SearchAsync(string keyword);

    Task<Result<DealDetailsDto>> GetWithDetailsAsync(int id);
    Task<Result<List<DealDto>>> GetWithCustomerAsync(int customerId);
    Task<Result<List<DealDto>>> GetWithCompanyAsync(int companyId);

    Task<Result<bool>> ChangeStatusAsync(int id, DealStatus status);
    Task<Result<bool>> CloseAsWonAsync(int id);
    Task<Result<bool>> CloseAsLostAsync(int id);
    Task<Result<bool>> UpdateEstimatedValueAsync(int id, decimal value);
    Task<Result<bool>> UpdateDeadlineAsync(int id, DateTime? deadline);

    Task<Result<decimal>> GetTotalEstimatedValueByCompanyAsync(int companyId);
    Task<Result<int>> GetDealCountByStatusAsync(DealStatus status);
    Task<Result<decimal>> GetTotalPipelineValueAsync();
}
