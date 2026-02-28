namespace C_.Concepts.fullPractice
{
    public class Note : Entity
    {
        private string title;
        private string description;
        private readonly IReadOnlyList<AditionalNoteDetails>? aditionalNoteDetails;

        protected Note(string id, string title, string description)
        {
            base.Id = id;
            this.title = title;
            this.description = description;
        }

        public string NoteId => base.Id;
        public string Title
        {
            get { return title; }
        }
        public string Description => description;

        public static Note CreateNote(string id, string title, string description)
        {
            return new Note(id, title, description);
        }
    }
}
