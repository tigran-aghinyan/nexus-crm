using NexusCRM.Web.Entities;
using NexusCRM.Web.Entities.Enums;

namespace NexusCRM.Web.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByIdAsync(string id);
    Task<List<User>> GetByCompanyIdAsync(int companyId);
    Task<List<User>> GetByRoleAsync(UserRole role);
    Task<User?> GetByEmailAsync(string email);
    Task<List<User>> GetByUserNameAsync(string userName);
    Task<User?> GetByPhoneNumberAsync(string phoneNumber);
    Task<User?> GetByIdentifierAsync(string identifier);

    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByUserNameAsync(string userName);
    Task<bool> ExistsByPhoneNumberAsync(string phoneNumber);
}