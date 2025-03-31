using Asp.Learning.Contracts;
using Asp.Learning.Dtos.responses;
using Asp.Learning.repositories.Entities;
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
        var author = new Author
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            DateOfBirth = command.DateOfBirth,
            DateOfDeath = command.DateOfDeath,
            MainCategory = command.MainCategory,
            Courses = command.Courses.Select(course => new Course
            {
                Title = course.Title,
                Description = course.Description,
            }).ToList(),
        };
        return repository.AddAsync(author);
    }
}
