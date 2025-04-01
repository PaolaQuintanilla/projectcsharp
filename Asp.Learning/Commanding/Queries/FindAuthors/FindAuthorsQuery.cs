using Asp.Learning.Helpers;
using Asp.Learning.repositories.Entities;
using Asp.Learning.ResourceParameters;

namespace Asp.Learning.Commanding.Queries.FindAuthors;
public class FindAuthorsQuery : IQuery<PagedList<Author>>
{
    public AuthorResourceParameters AuthorResourceParameters { get; set; }
}