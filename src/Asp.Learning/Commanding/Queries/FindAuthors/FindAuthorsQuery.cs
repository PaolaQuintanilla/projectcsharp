using Asp.Learning.Services.domain;

namespace Asp.Learning.Commanding.Queries.FindAuthors;
public class FindAuthorsQuery : IQuery<IReadOnlyList<Author>>
{
    public string MainCategory { get; set; }
}