namespace Asp.Learning.Dtos.responses;

public class AuthorV2Dto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public string MainCategory { get; set; }
}
