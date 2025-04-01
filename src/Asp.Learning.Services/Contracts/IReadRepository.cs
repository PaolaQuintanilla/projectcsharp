namespace Asp.Learning.Contracts.Services
{
    public interface IReadRepository<T>
        where T : class
    {
        Task<T> FindAsync(Guid id);
        Task<IReadOnlyList<T>> FindAsync();
        Task<IReadOnlyList<T>> FindAsync(string? mainCategory);
    }
}
