using Asp.Learning.Contracts.Services;
using Asp.Learning.Dtos.responses;
using Asp.Learning.Services.domain;
using AutoMapper;

namespace Asp.Learning.Commanding.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : ICommandHandler<CreateAuthorCommand, Guid>
{
    private readonly IWriteRepository<Author> repository;
    //private readonly IMapper _mapper;
    public CreateAuthorCommandHandler(IMapper mapper, IWriteRepository<Author> repository)
    {
        //_mapper = mapper;
        this.repository = repository;
    }
    public Task<Guid> HandleAsync(CreateAuthorCommand command)
    {
        //var authorEntity = _mapper.Map<Author>(command);
        var author = Author.CreateNew(
            command.FirstName,
            command.LastName,
            command.MainCategory,
            command.DateOfBirth,
            command.DateOfDeath
        );

        if (author == null) 
        {
            return null;
        }

        return repository.AddAsync(author);
    }
}
