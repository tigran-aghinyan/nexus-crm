using Microsoft.EntityFrameworkCore;
using NexusCRM.Web.Data;
using NexusCRM.Web.Entities;
using NexusCRM.Web.Repositories.Interfaces;
namespace NexusCRM.Web.Repositories.Implementations;

public class NoteRepository(AppDbContext context) : INoteRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddAsync(Note entity)
        => await _context.Notes.AddAsync(entity);

    public async Task Delete(Note entity)
        => _context.Notes.Remove(entity);

    public Task<bool> ExistsByIdAsync(int id)
        => _context.Notes.AnyAsync(n => n.Id == id);

    public async Task<List<Note>> GetAllAsync()
        => await _context.Notes.
            Include(n => n.Author).
            ToListAsync();

    public async Task<List<Note>> GetByAuthorIdAsync(string authorId)
        => await _context.Notes.Where(n => n.AuthorId == authorId).ToListAsync();

    public async Task<Note?> GetByIdAsync(int id)
        => await _context.Notes.FindAsync(id);

    public async Task<List<Note>> GetRecentAsync(int count)
        => await _context.Notes.TakeLast(count).ToListAsync();

    public async Task<List<Note>> GetTimelineByDateRangeAsync(DateTime from, DateTime to)
        => await _context.Notes.Where(n => n.CreatedAt > from && n.CreatedAt < to).ToListAsync();

    public async Task<List<Note>> GetTimelineByUserAsync(string userId)
        => await _context.Notes.
                Where(n => n.AuthorId == userId).
                Include(n => n.CreatedAt).
                OrderBy(n => n.CreatedAt).
                ToListAsync();

    public async Task<Note?> GetWithAuthorAsync(int id)
        => await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

    public async Task<List<Note>> GetWithAuthorsAsync()
        => await _context.Notes.
                Include(n => n.Author).
                ToListAsync();

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();

    public async Task<List<Note>> SearchAsync(string keyword)
        => await _context.Notes.Where(n => n.Content.Contains(keyword)).ToListAsync();

    public void Update(Note entity)
        => _context.Update(entity);
}
