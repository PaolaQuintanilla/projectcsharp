namespace Asp.Learning.Dtos.responses;

public class AuthorV1Dto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public DateTimeOffset? DateOfDeath { get; set; }
    public string MainCategory { get; set; }
}
