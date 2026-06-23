using NexusCRM.Web.DTOs.Tasks;

namespace NexusCRM.Web.Services.Interfaces;

public interface IWorkTaskService
{
    Task<Result<bool>> AddAsync(CreateTaskDto dto);
    Task<Result<bool>> UpdateAsync(int id, UpdateTaskDto dto);
    Task<Result<DetailsTaskDto>> GetByIdAsync(int id);
    Task<Result<List<DetailsTaskDto>>> GetAllAsync();
    Task<Result<bool>> DeleteAsync(int id);

    Task<Result<List<DetailsTaskDto>>> GetByUserIdAsync(string userId);
    Task<Result<List<DetailsTaskDto>>> GetByDealIdAsync(int dealId);
    Task<Result<List<DetailsTaskDto>>> GetCompletedAsync();
    Task<Result<List<DetailsTaskDto>>> GetPendingAsync();
    Task<Result<List<DetailsTaskDto>>> GetOverdueAsync();
    Task<Result<int>> GetCompletedCountByUserAsync(string userId);
    Task<Result<int>> GetPendingCountByUserAsync(string userId);
    Task<Result<int>> GetOverdueCountByUserAsync(string userId);
    Task<Result<DetailsTaskDto>> GetWithDetailsAsync(int id);
    Task<Result<List<DetailsTaskDto>>> GetWithUserAsync(string userId);
    Task<Result<List<DetailsTaskDto>>> GetWithDealAsync(int dealId);

    Task<Result<bool>> MarkAsCompletedAsync(int id);
    Task<Result<bool>> MarkAsPendingAsync(int id);
    Task<Result<bool>> AssignToUserAsync(int taskId, string userId);
    Task<Result<bool>> ChangeDeadlineAsync(int taskId, DateTime deadline);

    Task<bool> ExistsByIdAsync(int id);
}
