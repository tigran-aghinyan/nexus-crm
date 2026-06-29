using NexusCRM.Web.DTOs.Companies;

namespace NexusCRM.Web.Services.Interfaces;

public interface ICompanyService
{
    Task<Result<bool>> AddAsync(CreateCompanyDto dto);
    Task<Result<bool>> UpdateAsync(int id, UpdateCompanyDto dto);
    Task<Result<bool>> DeleteAsync(int id);

    Task<Result<List<CompanyDto>>> GetAllAsync();
    Task<Result<CompanyDto>> GetByIdAsync(int id);
    Task<Result<List<CompanyDto>>> GetActiveAsync();
    Task<Result<List<CompanyDto>>> SearchAsync(string keyword);
    Task<Result<CompanyDto>> GetByEmailAsync(string email);
    Task<Result<CompanyDto>> GetByPhoneAsync(string phone);
    Task<Result<List<CompanyDto>>> GetByIndustryAsync(string industry);

    Task<Result<CompanyDto>> GetWithDetailsAsync(int id);
    Task<Result<CompanyDto>> GetWithCustomersAsync(int id);
    Task<Result<CompanyDto>> GetWithDealsAsync(int id);
    Task<Result<int>> GetCustomerCountAsync(int companyId);
    Task<Result<int>> GetDealCountAsync(int companyId);

    Task<Result<bool>> ActivateAsync(int id);
    Task<Result<bool>> DeactivateAsync(int id);

    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByPhoneAsync(string phone);
}
