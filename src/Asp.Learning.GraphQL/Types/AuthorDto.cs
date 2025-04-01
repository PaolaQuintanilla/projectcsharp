namespace Asp.Learning.GraphQl.Types;

public class AuthorDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public DateTimeOffset? DateOfDeath { get; set; }
    public string MainCategory { get; set; }
    public List<CourseDto>? Courses { get; set; }
}
