namespace Asp.Learning.Contracts
{
    public interface IReadRepository<T>
        where T : class
    {
        T Find(Guid id);
        IReadOnlyList<T> Find();
    }
}
