using Asp.Learning.Contracts.Services;
using Asp.Learning.repositories.Entities;

namespace Asp.Learning.repositories.Services;

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
    public async Task<Author> FindAsync(Guid id)
    {
        var authorsChache = this.redis.Find(id);

        if (authorsChache is null)
        {
            return await this.repository.FindAsync(id);
        }

        return authorsChache;
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Author>> FindAsync()
    {
        var authorsChache = this.redis.Find();

        if (authorsChache.Count() == 0)
        {
            return await this.repository.FindAsync();
        }

        return authorsChache;
    }

    public async Task<IReadOnlyList<Author>> FindAsync(string mainCategory)
    {
        var authorsChache = this.redis.Find();

        if (authorsChache.Count() == 0)
        {
            return await this.repository.FindAsync(mainCategory);
        }

        return authorsChache.Where((a) => a.MainCategory == mainCategory).ToList();
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
