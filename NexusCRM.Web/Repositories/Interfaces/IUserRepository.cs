using NexusCRM.Web.Entities;
using NexusCRM.Web.Entities.Enums;

namespace NexusCRM.Web.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    // ---------------- CRM FILTERS ----------------

    Task<List<User>> GetByCompanyIdAsync(int companyId);

    Task<List<User>> GetByRoleAsync(UserRole role);
    Task<User?> GetByEmailAsync(string email);

    Task<List<User>> GetByUserNameAsync(string userName);

    Task<User?> GetByPhoneNumberAsync(string phoneNumber);


    // ---------------- RELATIONSHIPS ----------------
    //                TODO: FOREIGN KEYS

    /*Task<User?> GetWithCustomersAsync(string id);

    Task<User?> GetWithDealsAsync(string id);

    Task<User?> GetWithDetailsAsync(string id);

    Task<int> GetCustomerCountAsync(string userId);

    Task<int> GetDealCountAsync(string userId);*/

    // ---------------- VALIDATION ----------------

    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByUserNameAsync(string userName);
    Task<bool> ExistsByPhoneNumberAsync(string phoneNumber);

    // ---------------- BUSINESS ACTIONS ----------------
    // TODO: IN SERVICE LAYER

    /*Task AssignRoleAsync(string userId, UserRole role);

    Task AssignCompanyAsync(string userId, int companyId);

    Task ActivateAsync(string userId);

    Task DeactivateAsync(string userId);*/

    // ---------------- CRM ACTIONS ----------------
    //                TODO: FOREIGN KEYS
    /*Task<List<Customer>> GetAssignedCustomersAsync(string userId);

    Task<List<Deal>> GetAssignedDealsAsync(string userId);*/
}