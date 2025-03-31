namespace Asp.Learning.Contracts
{
    public interface IReadRepository<T>
        where T : class
    {
        Task<T> FindAsync(Guid id);
        Task<IReadOnlyList<T>> FindAsync();
        Task<IReadOnlyList<T>> FindAsync(string? mainCategory);
    }
}
