using Asp.Learning.Contracts;
using Asp.Learning.repositories.Entities;

namespace Asp.Learning.Commanding.Queries
{
    public class FindAuthorsQueryHandler : IQueryHandler<FindAuthorsQuery, IReadOnlyList<Author>>
    {
        private readonly IRepository<Author> repository;

        public FindAuthorsQueryHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }
        public IReadOnlyList<Author> Handle(FindAuthorsQuery query)
        {
            return this.repository.Find();
        }
    }
}
