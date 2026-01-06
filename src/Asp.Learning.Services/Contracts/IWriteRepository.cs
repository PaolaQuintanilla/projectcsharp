using Asp.Learning.Services.domain;
using Asp.Learning.Services.repositories.context;

namespace Asp.Learning.Contracts.Services;
public interface IWriteRepository<T>
        where T : class
{
    Task<Guid> AddAsync(T entity);
    Task<T> FindAsync(Guid id);
    LearningDbContext GetContext();
    Task<int> SaveChangesASync();
}