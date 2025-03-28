namespace Asp.Learning.Contracts;
public interface IWriteRepository<T>
        where T : class
{
    Guid Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    int SaveChangesASync();
}