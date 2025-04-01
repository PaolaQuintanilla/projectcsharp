using Asp.Learning.Contracts.Services;
using Asp.Learning.repositories.Entities;

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

            var course = author.Courses.FirstOrDefault(course => course.Id == command.CourseId);

            if (course != null)
            {
                author.Courses.Remove(course);
            }

            await this.repository.SaveChangesASync();
            
            return command.CourseId;
        }
    }
}
