using Asp.Learning.Contracts.Services;
using Asp.Learning.repositories.Entities;

namespace Asp.Learning.Commanding.Queries.FindAuthors
{
    public class FindAuthorsQueryHandler : IQueryHandler<FindAuthorsQuery, IReadOnlyList<Author>>
    {
        private readonly IReadRepository<Author> repository;

        public FindAuthorsQueryHandler(IReadRepository<Author> repository)
        {
            this.repository = repository;
        }
        public Task<IReadOnlyList<Author>> Handle(FindAuthorsQuery query)
        {
            return repository.FindAsync(query.MainCategory);
        }
    }
}
