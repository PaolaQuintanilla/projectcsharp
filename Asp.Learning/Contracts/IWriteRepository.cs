namespace Asp.Learning.Contracts;
public interface IWriteRepository<T>
        where T : class
{
    Guid Add(T entity);
    T Find(Guid id);
    int SaveChangesASync();
}