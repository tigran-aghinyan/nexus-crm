using NexusCRM.Web.DTOs.Deals;
using NexusCRM.Web.Entities;
using NexusCRM.Web.Entities.Enums;
using NexusCRM.Web.Repositories.Interfaces;
using NexusCRM.Web.Services.Interfaces;

namespace NexusCRM.Web.Services.Implementations;

public class DealService(IDealRepository repository) : IDealService
{
    private readonly IDealRepository _repository = repository;

    public async Task<Result<bool>> AddAsync(CreateDealDto dto)
    {
        if (dto is null ||
            string.IsNullOrWhiteSpace(dto.Title) || dto.Title.Length > 20 ||
            string.IsNullOrWhiteSpace(dto.Description) ||
            dto.EstimatedValue < 0 ||
            dto.Deadline is null ||
            dto.CustomerId < 1 ||
            dto.CompanyId < 1)
            return Result<bool>.Fail("Invalid Deal Data");

        var deal = new Deal
        {
            Title = dto.Title,
            Description = dto.Description,
            EstimatedValue = dto.EstimatedValue,
            Status = dto.Status,
            CreatedAt = dto.CreatedAt,
            Deadline = dto.Deadline,
            CustomerId = dto.CustomerId,
            CompanyId = dto.CompanyId,
        };

        await _repository.AddAsync(deal);
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<bool>> UpdateAsync(int id, UpdateDealDto dto)
    {
        if (dto is null ||
            string.IsNullOrWhiteSpace(dto.Title) ||
            string.IsNullOrWhiteSpace(dto.Description) ||
            dto.EstimatedValue < 0)
            return Result<bool>.Fail("Invalid Deal Data");

        var deal = await _repository.GetByIdAsync(id);
        if (deal is null)
            return Result<bool>.Fail("Deal Not Found");

        deal.Title = dto.Title;
        deal.Description = dto.Description;
        deal.EstimatedValue = dto.EstimatedValue;
        deal.Deadline = dto.Deadline;

        _repository.Update(deal);
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<bool>> DeleteAsync(int id)
    {
        var deal = await _repository.GetByIdAsync(id);
        if (deal is null)
            return Result<bool>.Fail("Deal Not Found");

        await _repository.Delete(deal);
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<List<DealDto>>> GetAllAsync()
    {
        var deals = await _repository.GetAllAsync();
        return Result<List<DealDto>>.Success(MapToDto(deals));
    }

    public async Task<Result<DealDetailsDto>> GetByIdAsync(int id)
    {
        var deal = await _repository.GetByIdAsync(id);
        return deal is null
            ? Result<DealDetailsDto>.Fail("Deal Not Found")
            : Result<DealDetailsDto>.Success(MapToDetailsDto(deal));
    }

    public async Task<Result<List<DealDto>>> GetByStatusAsync(DealStatus status)
    {
        var deals = await _repository.GetByStatusAsync(status);
        return Result<List<DealDto>>.Success(MapToDto(deals));
    }

    public async Task<Result<List<DealDto>>> GetByCustomerIdAsync(int customerId)
    {
        if (customerId < 1)
            return Result<List<DealDto>>.Fail("Invalid Customer Id");

        var deals = await _repository.GetByCustomerIdAsync(customerId);
        return Result<List<DealDto>>.Success(MapToDto(deals));
    }

    public async Task<Result<List<DealDto>>> GetByCompanyIdAsync(int companyId)
    {
        if (companyId < 1)
            return Result<List<DealDto>>.Fail("Invalid Company Id");

        var deals = await _repository.GetByCompanyIdAsync(companyId);
        return Result<List<DealDto>>.Success(MapToDto(deals));
    }

    public async Task<Result<List<DealDto>>> GetActiveDealsAsync()
    {
        var deals = await _repository.GetActiveDealsAsync();
        return Result<List<DealDto>>.Success(MapToDto(deals));
    }

    public async Task<Result<List<DealDto>>> GetOverdueDealsAsync()
    {
        var deals = await _repository.GetOverdueDealsAsync();
        return Result<List<DealDto>>.Success(MapToDto(deals));
    }

    public async Task<Result<List<DealDto>>> SearchAsync(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return Result<List<DealDto>>.Fail("Invalid Search Keyword");

        var deals = await _repository.SearchAsync(keyword);
        return Result<List<DealDto>>.Success(MapToDto(deals));
    }

    public async Task<Result<DealDetailsDto>> GetWithDetailsAsync(int id)
    {
        var deal = await _repository.GetWithDetailsAsync(id);
        return deal is null
            ? Result<DealDetailsDto>.Fail("Deal Not Found")
            : Result<DealDetailsDto>.Success(MapToDetailsDto(deal));
    }

    public async Task<Result<List<DealDto>>> GetWithCustomerAsync(int customerId)
    {
        if (customerId < 1)
            return Result<List<DealDto>>.Fail("Invalid Customer Id");

        var deals = await _repository.GetWithCustomerAsync(customerId);
        return Result<List<DealDto>>.Success(MapToDto(deals));
    }

    public async Task<Result<List<DealDto>>> GetWithCompanyAsync(int companyId)
    {
        if (companyId < 1)
            return Result<List<DealDto>>.Fail("Invalid Company Id");

        var deals = await _repository.GetWithCompanyAsync(companyId);
        return Result<List<DealDto>>.Success(MapToDto(deals));
    }

    public async Task<Result<bool>> ChangeStatusAsync(int id, DealStatus status)
    {
        var deal = await _repository.GetByIdAsync(id);
        if (deal is null)
            return Result<bool>.Fail("Deal Not Found");

        deal.Status = status;
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<bool>> CloseAsWonAsync(int id)
    {
        var deal = await _repository.GetByIdAsync(id);
        if (deal is null)
            return Result<bool>.Fail("Deal Not Found");

        deal.Status = DealStatus.Ended;
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<bool>> CloseAsLostAsync(int id)
    {
        var deal = await _repository.GetByIdAsync(id);
        if (deal is null)
            return Result<bool>.Fail("Deal Not Found");

        deal.Status = DealStatus.Cancelled;
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<bool>> UpdateEstimatedValueAsync(int id, decimal value)
    {
        if (value < 0)
            return Result<bool>.Fail("Estimated Value Cannot Be Negative");

        var deal = await _repository.GetByIdAsync(id);
        if (deal is null)
            return Result<bool>.Fail("Deal Not Found");

        deal.EstimatedValue = value;
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<bool>> UpdateDeadlineAsync(int id, DateTime? deadline)
    {
        var deal = await _repository.GetByIdAsync(id);
        if (deal is null)
            return Result<bool>.Fail("Deal Not Found");

        deal.Deadline = deadline;
        await _repository.SaveAsync();

        return Result<bool>.Success();
    }

    public async Task<Result<decimal>> GetTotalEstimatedValueByCompanyAsync(int companyId)
    {
        if (companyId < 1)
            return Result<decimal>.Fail("Invalid Company Id");

        var total = await _repository.GetTotalEstimatedValueByCompanyAsync(companyId);
        return Result<decimal>.Success(total);
    }

    public async Task<Result<int>> GetDealCountByStatusAsync(DealStatus status)
    {
        var count = await _repository.GetDealCountByStatusAsync(status);
        return Result<int>.Success(count);
    }

    public async Task<Result<decimal>> GetTotalPipelineValueAsync()
    {
        var total = await _repository.GetTotalPipelineValueAsync();
        return Result<decimal>.Success(total);
    }

    public List<DealDto> MapToDto(List<Deal>? dealEntities)
    {
        if (dealEntities is null)
            return [];

        List<DealDto> dealDtos = new(dealEntities.Count);
        foreach (var deal in dealEntities)
            dealDtos.Add(MapToDto(deal));

        return dealDtos;
    }

    public DealDto MapToDto(Deal dealEntity)
        => new()
        {
            Id = dealEntity.Id,
            Title = dealEntity.Title ?? string.Empty,
            EstimatedValue = dealEntity.EstimatedValue ?? 0m,
            Status = dealEntity.Status,
            CustomerId = dealEntity.CustomerId,
            CompanyId = dealEntity.CompanyId,
        };

    public DealDetailsDto MapToDetailsDto(Deal dealEntity)
        => new()
        {
            Id = dealEntity.Id,
            Title = dealEntity.Title ?? string.Empty,
            Description = dealEntity.Description ?? string.Empty,
            EstimatedValue = dealEntity.EstimatedValue ?? 0m,
            Status = dealEntity.Status,
            CreatedAt = dealEntity.CreatedAt,
            Deadline = dealEntity.Deadline,
            CustomerId = dealEntity.CustomerId,
            Customer = dealEntity.Customer,
            CompanyId = dealEntity.CompanyId ?? 0,
        };
}
