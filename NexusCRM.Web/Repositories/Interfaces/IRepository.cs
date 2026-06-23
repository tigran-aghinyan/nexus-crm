namespace NexusCRM.Web.Repositories.Interfaces;

public interface IRepository<T>
{
    Task AddAsync (T entity);
    void Update(T entity);
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task Delete(T entity);
    Task SaveAsync();

    // TODO: Adding pagination | Task<List<T>> GetPagedAsync(int page, int pageSize);
}
