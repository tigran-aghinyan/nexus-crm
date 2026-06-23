using Microsoft.AspNetCore.Mvc;
using NexusCRM.Web.DTOs.Notes;
using NexusCRM.Web.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NexusCRM.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly INoteService _service;
    public NotesController(INoteService service)
        => _service = service;

    // GET: api/<NotesController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    // GET api/<NotesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    // POST api/<NotesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateNoteDto? dto)
    {
        var result = await _service.AddAsync(dto);
        return Ok(result);
    }

    // PUT api/<NotesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateNoteDto? dto)
    {
        var result = await _service.Update(id, dto);
        return Ok(result);
    }

    // DELETE api/<NotesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.Delete(id);
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string keyword)
    {
        var result = await _service.SearchAsync(keyword);
        return Ok(result);
    }
}
