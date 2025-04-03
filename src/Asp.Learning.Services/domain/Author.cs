namespace Asp.Learning.Services.domain;

public class Author
{
    private Guid _id;
    private string _firstName;
    private string _lastName;
    private DateTimeOffset _dateOfBirth;
    private DateTimeOffset? _dateOfDeath;
    private string _mainCategory;
    private ICollection<Course> _courses;
    public Guid Id => _id;
    public string FirstName => _firstName;
    public string LastName => _lastName;
    public DateTimeOffset DateOfBirth => _dateOfBirth;
    public DateTimeOffset? DateOfDeath => _dateOfDeath;
    public string MainCategory => _mainCategory;
    public ICollection<Course> Courses => _courses;

    protected Author()
    {
    }

    private Author(string firstName, string lastName, string mainCategory, DateTimeOffset birth, DateTimeOffset? deatch)
    {
        this._id = Guid.NewGuid();
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentNullException("sdsdsds");
        }

        _firstName = firstName;
        _lastName = lastName;
        _mainCategory = mainCategory;
        _dateOfBirth = birth;
        _dateOfDeath = deatch;
        this._courses = new List<Course>();
    }

    public static Author CreateNew(string firstName, string lastName, string mainCategory, DateTimeOffset birth, DateTimeOffset? deatch)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return null;
        }
        firstName = firstName.Trim();

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return null;
        }

        return new Author(firstName, lastName, mainCategory, birth, deatch);
    }
}