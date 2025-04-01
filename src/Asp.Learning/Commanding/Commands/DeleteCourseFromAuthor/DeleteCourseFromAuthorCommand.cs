namespace Asp.Learning.Commanding.Commands.DeleteCourseFromAuthor
{
    public class DeleteCourseFromAuthorCommand: ICommand
    {
        public Guid AuthorId { get; set; }
        public Guid CourseId { get; set; }

    }
}
