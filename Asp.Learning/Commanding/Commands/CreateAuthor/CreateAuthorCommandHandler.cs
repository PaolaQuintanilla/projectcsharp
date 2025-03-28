using Asp.Learning.Contracts;
using Asp.Learning.repositories.Entities;

namespace Asp.Learning.Commanding.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand, Guid>
{
    private readonly IWriteRepository<Author> repository;

    public CreateAuthorCommandHandler(IWriteRepository<Author> repository)
    {
        this.repository = repository;
    }
    public Guid HandleAsync(CreateAuthorCommand command)
    {
        var author = new Author
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            DateOfBirth = command.DateOfBirth,
            DateOfDeath = command.DateOfDeath,
            MainCategory = command.MainCategory,
        };
        return repository.Add(author);
    }
}
