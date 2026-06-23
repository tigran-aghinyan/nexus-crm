using NexusCRM.Web.DTOs.Users;

namespace NexusCRM.Web.Services.Interfaces;

public interface IAuthService
{
    Task<Result<bool>> RegisterAsync(RegisterCompanyAdminDto dto);
    Task<Result<bool>> LoginAsync(LoginUserDto dto);
}
