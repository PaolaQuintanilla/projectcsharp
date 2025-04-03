using Asp.Learning.Contracts.Services;
using Asp.Learning.Services.domain;

namespace Asp.Learning.Commanding.Queries.FindAuthor
{
    public class FindAuthorQueryHandler : IQueryHandler<FindAuthorQuery, Author>
    {
        private readonly IReadRepository<Author> repository;

        public FindAuthorQueryHandler(IReadRepository<Author> repository)
        {
            this.repository = repository;
        }
        public Task<Author> Handle(FindAuthorQuery query)
        {
            return repository.FindAsync(query.Id);
        }
    }
}
