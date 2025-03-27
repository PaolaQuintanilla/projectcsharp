namespace Asp.Learning.Contracts;
public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class
{
}