using Asp.Learning.Services.domain;

namespace Asp.Learning.Commanding.Queries.FindAuthor
{
    public class FindAuthorQuery : IQuery<Author>
    {
        public Guid Id { get; set; }
    }
}
