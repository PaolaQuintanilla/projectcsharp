namespace Asp.Learning.Commanding.Commands.AddBookToAuthor
{
    public class AddBookToAuthorCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
    }
}
