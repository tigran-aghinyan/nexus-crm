using NexusCRM.Web.DTOs.Notes;
using NexusCRM.Web.DTOs.Users;
using NexusCRM.Web.Entities.Enums;

namespace NexusCRM.Web.Services.Interfaces;

public interface IUserService
{
    Task<Result<bool>> UpdateAsync(string id, UpdateUserDto? dto);
    Task<Result<bool>> DeleteAsync(string id);

    Task<Result<List<DetailsUserDto>>> GetAllAsync();
    Task<Result<DetailsUserDto>> GetByIdAsync(string id);
    Task<Result<List<DetailsUserDto>>> GetByCompanyIdAsync(int companyId);
    Task<Result<List<DetailsUserDto>>> GetByRoleAsync(UserRole role);
    Task<Result<DetailsUserDto>> GetByEmailAsync(string email);
    Task<Result<List<DetailsUserDto>>> GetByUserNameAsync(string userName);
    Task<Result<DetailsUserDto>> GetByPhoneNumberAsync(string phoneNumber);

    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByUserNameAsync(string userName);
    Task<bool> ExistsByPhoneNumberAsync(string phoneNumber);

    Task<Result<bool>> AssignRoleAsync(string userId, UserRole role);
}
