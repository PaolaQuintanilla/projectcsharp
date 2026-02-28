namespace C_.Concepts.fullPractice
{
    public class NoteVs
    {
        private string noteId;
        private string title;
        private string description;
        private string id;
        private readonly IReadOnlyList<AditionalNoteDetails>? aditionalNoteDetails;

        protected NoteVs(string id, string title, string description)
        {
            this.id = id;
            this.title = title;
            this.description = description;
        }

        public string NoteId => noteId;
        public string Title
        {
            get { return title; }
        }
        public string Description => description;

        public static NoteVs CreateNote(string id, string title, string description)
        {
            return new NoteVs(id, title, description);
        }
    }
}
