using NexusCRM.Web.DTOs.Customers;
using NexusCRM.Web.Entities.Enums;

namespace NexusCRM.Web.Services.Interfaces;

public interface ICustomerService
{
    Task<Result<bool>> AddAsync(CreateCustomerDto dto);
    Task<Result<bool>> UpdateAsync(int id, UpdateCustomerDto dto);
    Task<Result<bool>> DeleteAsync(int id);

    Task<Result<List<CustomerDto>>> GetAllAsync();
    Task<Result<CustomerDetailsDto>> GetByIdAsync(int id);
    Task<Result<List<CustomerDto>>> GetActiveAsync();
    Task<Result<List<CustomerDto>>> GetByStatusAsync(CustomerStatus status);
    Task<Result<List<CustomerDto>>> SearchAsync(string keyword);
    Task<Result<List<CustomerDto>>> GetByCompanyIdAsync(int companyId);
    Task<Result<CustomerDto>> GetByPhoneAsync(string phone);

    Task<Result<CustomerDetailsDto>> GetWithDetailsAsync(int id);
    Task<Result<CustomerDetailsDto>> GetWithDealsAsync(int id);
    Task<Result<int>> GetDealCountAsync(int customerId);

    Task<Result<bool>> ActivateAsync(int id);
    Task<Result<bool>> DeactivateAsync(int id);
    Task<Result<bool>> ChangeStatusAsync(int id, CustomerStatus status);

    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByPhoneAsync(string phone);
}
