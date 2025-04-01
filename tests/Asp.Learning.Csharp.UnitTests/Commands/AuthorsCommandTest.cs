using Asp.Learning.Commanding.Commands;
using Asp.Learning.Commanding.Commands.AddBookToAuthor;
using Asp.Learning.Commanding.Commands.CreateAuthor;
using Asp.Learning.Contracts;
using Asp.Learning.Contracts.Services;
using Asp.Learning.repositories.Entities;
using AutoMapper;
using Moq;

namespace Asp.Learning.Csharp.UnitTests.Commands
{
    //private ICommandHandler<AddBookToAuthorCommand, Guid> command;
    public class AuthorsCommandTest
    {
        private CreateAuthorCommandHandler commandHandler;
        public AuthorsCommandTest()
        {
            //***** CONSTRUCTOR CONTEXT *****//////
            var repo = new Mock<IWriteRepository<Author>>();
            var mapper = new Mock<IMapper>();
            repo.Setup(x => x.AddAsync(It.IsAny<Author>()))
                .ReturnsAsync(Guid.NewGuid);

            commandHandler = new CreateAuthorCommandHandler(mapper.Object, repo.Object);
        }

        [Theory]
        [InlineData(
    "Oliver",
    "Castro",
    "1986-07-23T00:00:00+00:00",
    "1986-07-24T00:00:00+00:00",
    "Poetry")]
        [InlineData(
    "Alvaro",
    "Castro",
    "1986-07-23T00:00:00+00:00",
    "1986-07-24T00:00:00+00:00",
    "Poetry")]
        public async Task Test_CreateAuthorCommand(string firstName,
    string lastName,
    string DateOfBirth,
    string DateOfDeath,
    string MainCategory)
        {
            var author = new CreateAuthorCommand
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = DateTime.Parse(DateOfBirth),
                DateOfDeath = DateTime.Parse(DateOfDeath),
                MainCategory = MainCategory
            };

            var result = await this.commandHandler.HandleAsync(author);

            Assert.IsType<Guid>(result);
        }
    }
}
