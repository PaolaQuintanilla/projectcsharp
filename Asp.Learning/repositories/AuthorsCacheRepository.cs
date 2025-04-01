using Asp.Learning.Contracts;
using Asp.Learning.Helpers;
using Asp.Learning.repositories.Entities;
using Asp.Learning.ResourceParameters;

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

    public async Task<PagedList<Author>> FindAsync(AuthorResourceParameters authorResourceParameters)
    {
        var authorsChache = this.redis.Find();

        if (authorsChache.Count() == 0)
        {
            return await this.repository.FindAsync(authorResourceParameters);
        }

        if (!string.IsNullOrWhiteSpace(authorResourceParameters.MainCategory))
        {
            var mainCategory = authorResourceParameters.MainCategory.Trim();
            authorsChache = authorsChache.Where((a) => a.MainCategory == mainCategory).ToList();
        }

        if (!string.IsNullOrWhiteSpace(authorResourceParameters.SearchQuery))
        {
            var searchQuery = authorResourceParameters.SearchQuery.Trim();
            authorsChache = authorsChache.Where((a) => a.MainCategory.Contains(searchQuery)
                || a.FirstName.Contains(searchQuery)
                || a.LastName.Contains(searchQuery)).ToList();
        }

        return await PagedList<Author>.CreateAsync(authorsChache.AsQueryable(), authorResourceParameters.PageNumber,
            authorResourceParameters.PageSize);
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
