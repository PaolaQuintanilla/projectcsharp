using Asp.Learning.Contracts;
using Asp.Learning.repositories.Entities;

namespace Asp.Learning.repositories;

//decorator pattern
//extendemos la funcionalidad sin necesidad de modificar el repositorio
public class AuthorsCacheRepository : IReadRepository<Author>
{
    private readonly IReadRepository<Author> repository;
    private readonly RedisCache redis;

    public AuthorsCacheRepository(IReadRepository<Author> repository, RedisCache redis)
    {
        this.repository = repository;
        this.redis = redis;
    }
    public Author Find(Guid id)
    {
        var authorsChache = this.redis.Find(id);

        if (authorsChache is null)
        {
            return this.repository.Find(id);
        }

        return authorsChache;
        throw new NotImplementedException();
    }

    public IReadOnlyList<Author> Find()
    {
        var authorsChache = this.redis.Find();

        if (authorsChache.Count() == 0)
        {
            return this.repository.Find();
        }

        return authorsChache;
    }
}

public class RedisCache
{
    public IReadOnlyList<Author> Find()
    {
        return new List<Author>();  
    }
    public Author Find(Guid id)
    {
        return null;
    }
}
