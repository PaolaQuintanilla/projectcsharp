namespace Asp.Learning.Contracts.Services;
public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class
{
}