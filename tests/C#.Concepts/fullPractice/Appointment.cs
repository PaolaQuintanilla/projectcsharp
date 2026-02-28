using System;

namespace C_.Concepts.fullPractice
{
    public class Appointment : Entity
    {
        private string title;
        private string description;
        private List<Note> notes;

        protected Appointment(string title, string description)
        {
            base.Id = Guid.NewGuid().ToString();
            this.title = title;
            this.description = description;
            this.notes = new List<Note>();
        }

        public string AppointmentId => base.Id;
        public string Title
        {
            get {  return title; }
        }
        public string Description => description;
        public IReadOnlyList<Note> Notes => notes;

        public static Appointment CreateNew(string title, string description)
        {
            return new Appointment(title, description);
        }

        public Appointment AddNote(Note? note)
        {
            if (note is null)
            {
                throw new ArgumentNullException();
            }

            this.notes.Add(note);

            return this;
        }

        public Appointment DeleteNote(Note note)
        {
            var noteIndex = this.notes.IndexOf(note);

            if(noteIndex != -1)
            {
                this.notes.RemoveAt(noteIndex);
            } else
            {
                throw new KeyNotFoundException();
            }

            return this;
        }

        public Appointment DeleteNote(string noteId)
        {
            var note = this.notes.FirstOrDefault(note => note.NoteId == noteId);

            if (note != null)
            {
                this.notes.Remove(note);
            }
            return this;
        }

        public Appointment UpdateNote(Note note)
        {
            if (note is null)
                throw new ArgumentNullException(nameof(note));

            var index = this.notes.FindIndex(n => n.NoteId == note.NoteId);

            if (index == -1)
                throw new InvalidOperationException("Note not found");

            this.notes[index] = note;

            return this;
        }

        public Note? GetNoteById(string noteId)
        {
            if (string.IsNullOrWhiteSpace(noteId))
            {
                throw new ArgumentNullException();
            }
            noteId = noteId.Trim();

            return this.notes.SingleOrDefault(note => note.NoteId == noteId);
        }

        public IReadOnlyList<Note> GetNotes()
        {
            if (notes == null)
            {
                return new List<Note>();
            }

            return notes;
        }

        internal void AddNotes(List<Note> notes)
        {
            if (notes != null)
            {
                this.notes.AddRange(notes);
            }
        }

        internal void CopyToNotes(Note[] array, int index)
        {
            this.notes.CopyTo(array, index);
        }

        internal void ClearNotes()
        {
            this.notes.Clear();
        }

        internal bool ExistsNote(Func<Note, bool> func)
        {
            return this.notes.Any(func);
        }

        internal IEnumerable<Note> FindNotes(Predicate<Note> predicate)
        {
            return this.notes.FindAll(predicate);
        }

        public bool RemoveNotes(Predicate<Note> predicate)
        {
            var result = this.notes.RemoveAll(predicate);
            return result > 0;
        }
    }
}
