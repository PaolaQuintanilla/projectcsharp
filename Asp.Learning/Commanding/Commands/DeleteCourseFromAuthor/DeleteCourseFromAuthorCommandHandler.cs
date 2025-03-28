using Asp.Learning.Contracts;
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
        public Guid HandleAsync(DeleteCourseFromAuthorCommand command)
        {
            var author = this.repository.Find(command.AuthorId);

            var course = author.Courses.FirstOrDefault(course => course.Id == command.CourseId);

            author.Courses.Remove(course);

            this.repository.SaveChangesASync();
            
            return command.CourseId;
        }
    }
}
