using Asp.Learning.Helpers;
using Asp.Learning.ResourceParameters;

namespace Asp.Learning.Contracts
{
    public interface IReadRepository<T>
        where T : class
    {
        Task<T> FindAsync(Guid id);
        Task<IReadOnlyList<T>> FindAsync();
        Task<PagedList<T>> FindAsync(AuthorResourceParameters a);
    }
}
