using NexusCRM.Web.Entities;

namespace NexusCRM.Web.Repositories.Interfaces;

public interface INoteRepository : IRepository<Note>
{
    Task<List<Note>> GetByAuthorIdAsync(string authorId);
    Task<List<Note>> GetRecentAsync(int count);
    Task<List<Note>> SearchAsync(string keyword);
    Task<Note?> GetWithAuthorAsync(int id);
    Task<List<Note>> GetWithAuthorsAsync();
    Task<List<Note>> GetTimelineByUserAsync(string userId);
    Task<List<Note>> GetTimelineByDateRangeAsync(DateTime from, DateTime to);

    Task<bool> ExistsByIdAsync(int id);
}
