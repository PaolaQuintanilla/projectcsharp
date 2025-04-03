namespace Asp.Learning.Services.domain;

public class Course
{
    //public static List<Course> EMPTY_COURSES = new List<Course>();
    private Guid _id;
    private string _title;
    private string? _description;
    public Guid Id => _id;
    public string Title => _title;
    public string? Description => _description;

    protected Course()
    {
    }

    private Course(string title, string? description)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        }


        _id = Guid.NewGuid();
        _title = title.Trim();
        _description = description?.Trim();
    }

    public static Course CreateNew(string title, string? description)
    {
        return new Course(title, description);
    }
}
