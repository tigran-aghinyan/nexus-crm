using Microsoft.AspNetCore.Mvc;
using NexusCRM.Web.DTOs.Customers;
using NexusCRM.Web.Entities.Enums;
using NexusCRM.Web.Services.Interfaces;

namespace NexusCRM.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(ICustomerService service) : ApiControllerBase
{
    private readonly ICustomerService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return HandleResult(result);
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        var result = await _service.GetActiveAsync();
        return HandleResult(result);
    }

    [HttpGet("by-status")]
    public async Task<IActionResult> GetByStatus([FromQuery] CustomerStatus status)
    {
        var result = await _service.GetByStatusAsync(status);
        return HandleResult(result);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string keyword)
    {
        var result = await _service.SearchAsync(keyword);
        return HandleResult(result);
    }

    [HttpGet("by-company/{companyId}")]
    public async Task<IActionResult> GetByCompany(int companyId)
    {
        var result = await _service.GetByCompanyIdAsync(companyId);
        return HandleResult(result);
    }

    [HttpGet("{id}/details")]
    public async Task<IActionResult> GetWithDetails(int id)
    {
        var result = await _service.GetWithDetailsAsync(id);
        return HandleResult(result);
    }

    [HttpGet("{id}/deals")]
    public async Task<IActionResult> GetWithDeals(int id)
    {
        var result = await _service.GetWithDealsAsync(id);
        return HandleResult(result);
    }

    [HttpGet("{id}/deal-count")]
    public async Task<IActionResult> GetDealCount(int id)
    {
        var result = await _service.GetDealCountAsync(id);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCustomerDto? dto)
    {
        var result = await _service.AddAsync(dto);
        return HandleResult(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateCustomerDto? dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return HandleResult(result);
    }

    [HttpPatch("{id}/activate")]
    public async Task<IActionResult> Activate(int id)
    {
        var result = await _service.ActivateAsync(id);
        return HandleResult(result);
    }

    [HttpPatch("{id}/deactivate")]
    public async Task<IActionResult> Deactivate(int id)
    {
        var result = await _service.DeactivateAsync(id);
        return HandleResult(result);
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> ChangeStatus(int id, [FromQuery] CustomerStatus status)
    {
        var result = await _service.ChangeStatusAsync(id, status);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return HandleResult(result);
    }
}
