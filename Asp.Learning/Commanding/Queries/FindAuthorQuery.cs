using Asp.Learning.repositories.Entities;

namespace Asp.Learning.Commanding.Queries
{
    public class FindAuthorQuery : IQuery<Author>
    {
        public Guid Id { get; set; }
    }
}
