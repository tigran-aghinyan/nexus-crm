using NexusCRM.Web.DTOs.Customers;
using NexusCRM.Web.Entities;
using NexusCRM.Web.Entities.Enums;
using NexusCRM.Web.Repositories.Interfaces;
using NexusCRM.Web.Services.Interfaces;

namespace NexusCRM.Web.Services.Implementations;

public class CustomerService(ICustomerRepository repository) : ICustomerService
{
    private readonly ICustomerRepository _repository = repository;

    public async Task<Result<bool>> AddAsync(CreateCustomerDto dto)
    {
        if (dto is null ||
            string.IsNullOrWhiteSpace(dto.FullName) || dto.FullName.Length > 100 ||
            string.IsNullOrWhiteSpace(dto.Email) || dto.Email.Length > 30 ||
            dto.Address is null ||
            dto.CompanyId < 1)
            return Result<bool>.Fail("Invalid Customer Data");

        if (await _repository.ExistsByEmailAsync(dto.Email))
            return Result<bool>.Fail("Customer With This Email Already Exists");

        if (!string.IsNullOrWhiteSpace(dto.PhoneNumber) && await _repository.ExistsByPhoneAsync(dto.PhoneNumber))
            return Result<bool>.Fail("Customer With This Phone Already Exists");

        var customer = new Customer
        {
            FullName = dto.FullName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Address = MapToAddress(dto.Address),
            Status = CustomerStatus.New,
            CompanyId = dto.CompanyId,
        };

        await _repository.AddAsync(customer);
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<bool>> UpdateAsync(int id, UpdateCustomerDto dto)
    {
        if (dto is null ||
            string.IsNullOrWhiteSpace(dto.FullName) || dto.FullName.Length > 100 ||
            string.IsNullOrWhiteSpace(dto.Email) || dto.Email.Length > 30 ||
            dto.Address is null)
            return Result<bool>.Fail("Invalid Customer Data");

        var customer = await _repository.GetByIdAsync(id);
        if (customer is null)
            return Result<bool>.Fail("Customer Not Found");

        customer.FullName = dto.FullName;
        customer.Email = dto.Email;
        customer.PhoneNumber = dto.PhoneNumber;
        customer.Address = MapToAddress(dto.Address);
        customer.Status = dto.Status;

        _repository.Update(customer);
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<bool>> DeleteAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);
        if (customer is null)
            return Result<bool>.Fail("Customer Not Found");

        await _repository.Delete(customer);
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<List<CustomerDto>>> GetAllAsync()
    {
        var customers = await _repository.GetAllAsync();
        return Result<List<CustomerDto>>.Success(MapToDto(customers));
    }

    public async Task<Result<CustomerDetailsDto>> GetByIdAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);
        return customer is null
            ? Result<CustomerDetailsDto>.Fail("Customer Not Found")
            : Result<CustomerDetailsDto>.Success(MapToDetailsDto(customer));
    }

    public async Task<Result<List<CustomerDto>>> GetActiveAsync()
    {
        var customers = await _repository.GetActiveAsync();
        return Result<List<CustomerDto>>.Success(MapToDto(customers));
    }

    public async Task<Result<List<CustomerDto>>> GetByStatusAsync(CustomerStatus status)
    {
        var customers = await _repository.GetByStatusAsync(status);
        return Result<List<CustomerDto>>.Success(MapToDto(customers));
    }

    public async Task<Result<List<CustomerDto>>> SearchAsync(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return Result<List<CustomerDto>>.Fail("Invalid Search Keyword");

        var customers = await _repository.SearchAsync(keyword);
        return Result<List<CustomerDto>>.Success(MapToDto(customers));
    }

    public async Task<Result<List<CustomerDto>>> GetByCompanyIdAsync(int companyId)
    {
        if (companyId < 1)
            return Result<List<CustomerDto>>.Fail("Invalid Company Id");

        var customers = await _repository.GetByCompanyIdAsync(companyId);
        return Result<List<CustomerDto>>.Success(MapToDto(customers));
    }

    public async Task<Result<CustomerDto>> GetByPhoneAsync(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return Result<CustomerDto>.Fail("Invalid Phone");

        var customer = await _repository.GetByPhoneAsync(phone);
        return customer is null
            ? Result<CustomerDto>.Fail("Customer Not Found")
            : Result<CustomerDto>.Success(MapToDto(customer));
    }

    public async Task<Result<CustomerDetailsDto>> GetWithDetailsAsync(int id)
    {
        var customer = await _repository.GetWithDetailsAsync(id);
        return customer is null
            ? Result<CustomerDetailsDto>.Fail("Customer Not Found")
            : Result<CustomerDetailsDto>.Success(MapToDetailsDto(customer));
    }

    public async Task<Result<CustomerDetailsDto>> GetWithDealsAsync(int id)
    {
        var customer = await _repository.GetWithDealsAsync(id);
        return customer is null
            ? Result<CustomerDetailsDto>.Fail("Customer Not Found")
            : Result<CustomerDetailsDto>.Success(MapToDetailsDto(customer));
    }

    public async Task<Result<int>> GetDealCountAsync(int customerId)
    {
        if (customerId < 1)
            return Result<int>.Fail("Invalid Customer Id");

        var count = await _repository.GetDealCountAsync(customerId);
        return Result<int>.Success(count);
    }

    public async Task<Result<bool>> ActivateAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);
        if (customer is null)
            return Result<bool>.Fail("Customer Not Found");

        customer.Status = CustomerStatus.Active;
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<bool>> DeactivateAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);
        if (customer is null)
            return Result<bool>.Fail("Customer Not Found");

        customer.Status = CustomerStatus.Inactive;
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<bool>> ChangeStatusAsync(int id, CustomerStatus status)
    {
        var customer = await _repository.GetByIdAsync(id);
        if (customer is null)
            return Result<bool>.Fail("Customer Not Found");

        customer.Status = status;
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        return await _repository.ExistsByEmailAsync(email);
    }

    public async Task<bool> ExistsByPhoneAsync(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;
        return await _repository.ExistsByPhoneAsync(phone);
    }

    public List<CustomerDto> MapToDto(List<Customer>? customerEntities)
    {
        if (customerEntities is null)
            return [];

        List<CustomerDto> customerDtos = new(customerEntities.Count);
        foreach (var customer in customerEntities)
            customerDtos.Add(MapToDto(customer));

        return customerDtos;
    }

    public CustomerDto MapToDto(Customer customerEntity)
        => new()
        {
            Id = customerEntity.Id,
            FullName = customerEntity.FullName ?? string.Empty,
            Email = customerEntity.Email ?? string.Empty,
            PhoneNumber = customerEntity.PhoneNumber,
            Status = customerEntity.Status,
            CompanyId = customerEntity.CompanyId,
        };

    public CustomerDetailsDto MapToDetailsDto(Customer customerEntity)
        => new()
        {
            Id = customerEntity.Id,
            FullName = customerEntity.FullName ?? string.Empty,
            Email = customerEntity.Email ?? string.Empty,
            Phone = customerEntity.PhoneNumber,
            Address = customerEntity.Address is null ? null! : MapToAddressDto(customerEntity.Address),
            Status = customerEntity.Status,
            CreatedAt = customerEntity.CreatedAt,
            CompanyId = customerEntity.CompanyId,
            Deals = MapToDealSummary(customerEntity.Deals),
        };

    private static List<DealSummaryDto>? MapToDealSummary(List<Deal>? deals)
    {
        if (deals is null)
            return null;

        List<DealSummaryDto> dealDtos = new(deals.Count);
        foreach (var deal in deals)
        {
            dealDtos.Add(new DealSummaryDto
            {
                Id = deal.Id,
                Title = deal.Title,
                EstimatedValue = deal.EstimatedValue,
                Status = deal.Status,
                CreatedAt = deal.CreatedAt,
                Deadline = deal.Deadline,
                CustomerId = deal.CustomerId,
                CompanyId = deal.CompanyId,
            });
        }
        return dealDtos;
    }

    private static Address MapToAddress(AddressDto dto)
        => new()
        {
            Country = dto.Country,
            Region = dto.Region,
            City = dto.City,
            Street = dto.Street,
            PostalCode = dto.PostalCode,
        };

    private static AddressDto MapToAddressDto(Address address)
        => new()
        {
            Country = address.Country ?? string.Empty,
            Region = address.Region,
            City = address.City ?? string.Empty,
            Street = address.Street,
            PostalCode = address.PostalCode,
        };
}
