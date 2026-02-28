namespace C_.Concepts.fullPractice
{
    public class AppointmentVs
    {
        private string noteId;
        private string title;
        private string description;
        private List<NoteVs> notes;


        public string NoteId => noteId;
        public string Title
        {
            get {  return title; }
        }
        public string Description => description;
        public IReadOnlyList<NoteVs> Notes => notes;



        public AppointmentVs AddNote(NoteVs note)
        {
            return null;
        }

        public AppointmentVs DeleteNote(NoteVs note)
        {
            return null;
        }

        public AppointmentVs DeleteNote(string noteId)
        {
            return null;
        }

        public AppointmentVs UpdateNote(NoteVs note)
        {
            return null;
        }

        public NoteVs GetNoteById(string noteId)
        {
            return NoteVs.CreateNote("1", "", "");
        }


        public IReadOnlyList<NoteVs> GetNotes()
        {
            return null;
        }
    }
}
