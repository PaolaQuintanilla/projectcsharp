namespace Asp.Learning.GraphQl.Types;

public class AuthorType
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public DateTimeOffset? DateOfDeath { get; set; }
    public string MainCategory { get; set; }
    public List<CourseType>? Courses { get; set; }
}
