using Asp.Learning.Contracts;
using Asp.Learning.repositories.Entities;

namespace Asp.Learning.Commanding.Queries
{
    public class FindAuthorQueryHandler : IQueryHandler<FindAuthorQuery, Author>
    {
        private readonly IRepository<Author> repository;

        public FindAuthorQueryHandler(IRepository<Author> repository)
        {
            this.repository = repository;
        }
        public Author Handle(FindAuthorQuery query)
        {
            return this.repository.Find(query.Id);
        }
    }
}
