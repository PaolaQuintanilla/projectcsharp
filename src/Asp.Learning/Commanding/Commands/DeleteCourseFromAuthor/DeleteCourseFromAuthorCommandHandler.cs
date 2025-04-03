using Asp.Learning.Contracts.Services;
using Asp.Learning.Services.domain;

namespace Asp.Learning.Commanding.Commands.DeleteCourseFromAuthor
{
    public class DeleteCourseFromAuthorCommandHandler : ICommandHandler<DeleteCourseFromAuthorCommand, Guid>
    {
        private readonly IWriteRepository<Author> repository;

        public DeleteCourseFromAuthorCommandHandler(IWriteRepository<Author> repository)
        {
            this.repository = repository;
        }
        public async Task<Guid> HandleAsync(DeleteCourseFromAuthorCommand command)
        {
            var author = await this.repository.FindAsync(command.AuthorId);

            if (author is null)
            {
                throw new ArgumentException();
            }

            var course = author.Courses.FirstOrDefault(course => course.Id == command.CourseId);

            if (course == null)
            {
                throw new ArgumentException();
            }

            author.Courses.Remove(course);
            await this.repository.SaveChangesASync();
            
            return command.CourseId;
        }
    }
}
