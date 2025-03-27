namespace Asp.Learning.Contracts
{
    public interface IReadRepository<T>
        where T : class
    {
        T Find(int id);
        IReadOnlyList<T> Find();
    }
}
