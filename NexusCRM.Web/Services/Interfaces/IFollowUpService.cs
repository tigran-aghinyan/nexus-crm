using NexusCRM.Web.DTOs.FollowUps;
using NexusCRM.Web.Entities;

namespace NexusCRM.Web.Services.Interfaces;

public interface IFollowUpService
{
    Task<Result<bool>> AddAsync(CreateFollowUpDto dto);
    Task<Result<bool>> UpdateAsync(int id, UpdateFollowUpDto entity);
    Task<Result<bool>> DeleteAsync(int id);

    Task<Result<List<DetailsFollowUpDto>>> GetAllAsync();
    Task<Result<DetailsFollowUpDto?>> GetByIdAsync(int id);
    Task<Result<List<DetailsFollowUpDto>>> GetByDealIdAsync(int dealId);
    Task<Result<List<DetailsFollowUpDto>>> GetByUserIdAsync(string userId);
    Task<Result<List<DetailsFollowUpDto>>> GetByTaskIdAsync(int taskId);
    Task<Result<List<DetailsFollowUpDto>>> GetPendingAsync();
    Task<Result<List<DetailsFollowUpDto>>> GetCompletedAsync();
    Task<Result<DetailsFollowUpDto?>> GetWithDetailsAsync(int id);
    Task<Result<List<DetailsFollowUpDto>>> GetWithDealAsync(int dealId);
    Task<Result<List<DetailsFollowUpDto>>> GetWithUserAsync(string userId);
    Task<Result<int>> GetCompletedCountByUserAsync(string userId);
    Task<Result<int>> GetPendingCountByUserAsync(string userId);
    Task<Result<int>> GetTotalByDealAsync(int dealId);

    Task<Result<bool>> MarkAsCompletedAsync(int id);
    Task<Result<bool>> MarkAsPendingAsync(int id);
    Task<Result<bool>> CompleteAllForDealAsync(int dealId);

    Task<bool> ExistsByIdAsync(int id);

}
