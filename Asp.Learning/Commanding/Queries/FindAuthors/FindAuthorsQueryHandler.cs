using Asp.Learning.Contracts;
using Asp.Learning.Helpers;
using Asp.Learning.repositories.Entities;

namespace Asp.Learning.Commanding.Queries.FindAuthors
{
    public class FindAuthorsQueryHandler : IQueryHandler<FindAuthorsQuery, PagedList<Author>>
    {
        private readonly IReadRepository<Author> repository;

        public FindAuthorsQueryHandler(IReadRepository<Author> repository)
        {
            this.repository = repository;
        }
        public Task<PagedList<Author>> Handle(FindAuthorsQuery query)
        {
            return repository.FindAsync(query.AuthorResourceParameters);
        }
    }
}
