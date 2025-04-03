
using Asp.Learning.Contracts.Services;
using Asp.Learning.repositories.Entities;
using AutoMapper;

namespace Asp.Learning.Commanding.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : ICommandHandler<UpdateAuthorCommand, Guid>
    {
        private readonly IWriteRepository<Author> repository;
        //private readonly IMapper _mapper;
        public UpdateAuthorCommandHandler(IMapper mapper, IWriteRepository<Author> repository)
        {
            //_mapper = mapper;
            this.repository = repository;
        }
        public async Task<Guid> HandleAsync(UpdateAuthorCommand command)
        {
            var author = await repository.FindAsync(command.Id);
            author.FirstName = command.FirstName;
            author.LastName = command.LastName;
            author.DateOfBirth = command.DateOfBirth;
            author.DateOfDeath = command.DateOfDeath;
            author.MainCategory = command.MainCategory;

            await repository.SaveChangesASync();

            return author.Id;
        }
    }
}
