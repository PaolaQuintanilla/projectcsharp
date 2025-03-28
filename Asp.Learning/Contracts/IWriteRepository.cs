namespace Asp.Learning.Contracts;
public interface IWriteRepository<T>
        where T : class
{
    Task<Guid> AddAsync(T entity);
    Task<T> FindAsync(Guid id);
    Task<int> SaveChangesASync();
}