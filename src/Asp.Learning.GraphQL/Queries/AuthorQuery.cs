using Asp.Learning.Contracts.Services;
using Asp.Learning.GraphQl.Types;
using Asp.Learning.Services.domain;

namespace Asp.Learning.GraphQL.Queries;

public class AuthorQuery
{
    private readonly IReadRepository<Author> repository;

    public AuthorQuery(IReadRepository<Author> repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<AuthorType>> GetAuthors()
    {
        var response = await this.repository.FindAsync();
        var authors = response.Select(author => new AuthorType
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            DateOfBirth = author.DateOfBirth,
            DateOfDeath = author.DateOfDeath,
            MainCategory = author.MainCategory,
        });
        return authors;
    }
}
