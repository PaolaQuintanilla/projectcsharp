using Asp.Learning.Contracts;
using Asp.Learning.repositories.Entities;

namespace Asp.Learning.Commanding.Commands.DeleteCourseFromAuthor
{
    public class DeleteCourseFromAuthorCommandHandler : ICommandHandler<DeleteCourseFromAuthorCommand, Guid>
    {
        private readonly IRepository<Author> repository;

        public DeleteCourseFromAuthorCommandHandler(IRepository<Author> repository)
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
