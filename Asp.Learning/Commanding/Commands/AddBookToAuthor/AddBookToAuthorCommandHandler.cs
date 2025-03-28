using Asp.Learning.Contracts;
using Asp.Learning.repositories.Entities;

namespace Asp.Learning.Commanding.Commands.AddBookToAuthor;

public class AddBookToAuthorCommandHandler : ICommandHandler<AddBookToAuthorCommand, Guid>
{
    private readonly IWriteRepository<Author> repository;

    public AddBookToAuthorCommandHandler(IWriteRepository<Author> repository)
    {
        this.repository = repository;
    }
    public async Task<Guid> HandleAsync(AddBookToAuthorCommand command)
    {
        var author = await this.repository.FindAsync(command.AuthorId);
        if (author == null)
        {
            throw new ArgumentException("El autor no existe");
        }

        var curso = new Course
        {
            Description = command.Description,
            Title = command.Title,
        };

        author.Courses.Add(curso);

        var result = await this.repository.SaveChangesASync();

        if (result < 1)
        {
            throw new ArgumentException();
        }

        return author.Id;
    }
}
