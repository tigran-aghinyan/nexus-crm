using Microsoft.AspNetCore.Identity;
using NexusCRM.Web.DTOs.Users;
using NexusCRM.Web.Entities;
using NexusCRM.Web.Repositories.Interfaces;
using NexusCRM.Web.Services.Interfaces;

namespace NexusCRM.Web.Services.Implementations;

public class AuthService(IUserRepository userRepository, UserManager<User> userManager) : IAuthService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<Result<bool>> RegisterAsync(RegisterCompanyAdminDto dto)
    {
        if (dto is null)
            return Result<bool>.Fail("Invalid Register Data");

        var emailExists = await _userRepository.ExistsByEmailAsync(dto.Email);
        if (emailExists)
            return Result<bool>.Fail("Email is already registered");

        var phoneExists = await _userRepository.ExistsByPhoneNumberAsync(dto.PhoneNumber);
        if (phoneExists)
            return Result<bool>.Fail("Phone number is already registered");

        return Result<bool>.Success();
    }
    public async Task<Result<bool>> LoginAsync(LoginUserDto dto)
    {
        var user = await _userRepository.GetByIdentifierAsync(dto.Identifier);
        if (user is null)
            return Result<bool>.Fail("User Not Found");

        var passwordValid = await _userManager.CheckPasswordAsync(user,dto.Password);
        return passwordValid ? Result<bool>.Success() : Result<bool>.Fail("Invalid Credentials");
    }
}
