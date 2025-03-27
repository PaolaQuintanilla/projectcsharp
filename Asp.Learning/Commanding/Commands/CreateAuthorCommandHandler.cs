using Asp.Learning.Contracts;
using Asp.Learning.repositories.Entities;

namespace Asp.Learning.Commanding.Commands;

public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand, Guid>
{
    private readonly IRepository<Author> repository;

    public CreateAuthorCommandHandler(IRepository<Author> repository)
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
        return this.repository.Add(author);
    }
}
