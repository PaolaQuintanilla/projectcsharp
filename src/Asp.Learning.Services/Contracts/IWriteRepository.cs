namespace Asp.Learning.Contracts.Services;
public interface IWriteRepository<T>
        where T : class
{
    Task<Guid> AddAsync(T entity);
    Task<T> FindAsync(Guid id);
    Task<int> SaveChangesASync();
}