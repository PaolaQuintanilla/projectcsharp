using C_.Concepts.fullPractice;

namespace C_.Concepts
{
    public class AppointmentPractice
    {
        private static Note CreateMockNote(string id, string title = "Note", string description = "desc")
        {
            return Note.CreateNote(id, title, description);
        }

        private static Appointment CreateMockAppointment(string title = "Appointment", string description = "desc")
        {
            return Appointment.CreateNew(title, description);
        }

        [Fact]
        public void AddNote_ShouldAddNote_ToCollection()
        {
            var appointment = CreateMockAppointment();
            var note = CreateMockNote("1");

            appointment.AddNote(note);
            Assert.Contains(note, appointment.GetNotes());
        }

        [Fact]
        public void AddNote_ShouldReturnSameAppointment_ForFluentChaining()
        {
            var appointment = CreateMockAppointment();
            var note = CreateMockNote("1");

            var result = appointment.AddNote(note);

            Assert.Same(appointment, result);
        }

        [Fact]
        public void AddNote_ShouldThrow_WhenNoteIsNull()
        {
            var appointment = CreateMockAppointment();

            Assert.Throws<ArgumentNullException>(() => appointment.AddNote(null));
        }

        [Fact]
        public void DeleteNote_ByIndexObject_ShouldRemoveNote()
        {
            var appointment = CreateMockAppointment();
            var note = CreateMockNote("1");

            appointment.AddNote(note);

            appointment.DeleteNote(note);

            Assert.DoesNotContain(note, appointment.GetNotes());
        }

        [Fact]
        public void DeleteNote_ByDiferentInstance_withIdComparison_ShouldRemoveNote()
        {
            var appointment = CreateMockAppointment();
            var note = CreateMockNote("1");
            var anotherInstance = CreateMockNote("1");
            appointment.AddNote(note);

            appointment.DeleteNote(anotherInstance);

            Assert.DoesNotContain(note, appointment.GetNotes());
        }

        [Fact]
        public void DeleteNote_ById_ShouldRemoveCorrectNote()
        {
            var appointment = CreateMockAppointment();
            var note1 = CreateMockNote("1");
            var note2 = CreateMockNote("2");

            appointment.AddNote(note1);
            appointment.AddNote(note2);

            appointment.DeleteNote("1");

            Assert.DoesNotContain(note1, appointment.GetNotes());
            Assert.Contains(note2, appointment.GetNotes());
        }

        [Fact]
        public void UpdateNote_ShouldReplaceExistingNote()
        {
            var appointment = CreateMockAppointment();
            var original = CreateMockNote("1", "old", "old desc");
            var updated = CreateMockNote("1", "new", "new desc");

            appointment.AddNote(original);

            appointment.UpdateNote(updated);

            var result = appointment.GetNoteById("1");

            Assert.Equal("new", result.Title);
            Assert.Equal("new desc", result.Description);
        }

        [Fact]
        public void UpdateNote_ShouldThrow_WhenNoteDoesNotExist()
        {
            var appointment = CreateMockAppointment();
            var note = CreateMockNote("1");

            Assert.Throws<InvalidOperationException>(() => appointment.UpdateNote(note));
        }

        [Fact]
        public void GetNoteById_ShouldReturnCorrectNote()
        {
            var appointment = CreateMockAppointment();
            var note = CreateMockNote("1");

            appointment.AddNote(note);

            var result = appointment.GetNoteById("1");

            Assert.Equal(note, result);
        }

        [Fact]
        public void GetNoteById_ShouldReturnNull_WhenNotFound()
        {
            var appointment = CreateMockAppointment();

            var result = appointment.GetNoteById("999");

            Assert.Null(result);
        }

        [Fact]
        public void GetNotes_ShouldReturnAllNotes()
        {
            var appointment = CreateMockAppointment();
            var note1 = CreateMockNote("1");
            var note2 = CreateMockNote("2");

            appointment.AddNote(note1);
            appointment.AddNote(note2);

            var notes = appointment.GetNotes();

            Assert.Equal(2, notes.Count);
        }

        [Fact]
        public void GetNotes_ShouldReturnReadOnlyCollection()
        {
            var appointment = CreateMockAppointment();
            var note = CreateMockNote("1");

            appointment.AddNote(note);

            var notes = appointment.GetNotes();

            Assert.IsAssignableFrom<IReadOnlyList<Note>>(notes);
        }

        [Fact]
        public void Notes_Property_ShouldExposeReadOnlyCollection()
        {
            var appointment = CreateMockAppointment();
            var note = CreateMockNote("1");

            appointment.AddNote(note);

            Assert.Contains(note, appointment.Notes);
        }

        [Fact]
        public void AddRange_ShouldAddMultipleNotes()
        {
            var appointment = CreateMockAppointment();

            var notes = new List<Note>
            {
                CreateMockNote("1"),
                CreateMockNote("2"),
                CreateMockNote("3")
            };

            appointment.AddNotes(notes);

            Assert.Equal(3, appointment.GetNotes().Count);
        }

        [Fact]
        public void CopyTo_ShouldCopyNotesToArray()
        {
            var appointment = CreateMockAppointment();

            var note1 = CreateMockNote("1");
            var note2 = CreateMockNote("2");

            appointment.AddNote(note1)
                       .AddNote(note2);

            var array = new Note[2];

            appointment.CopyToNotes(array, 0);

            Assert.Equal(note1, array[0]);
            Assert.Equal(note2, array[1]);
        }

        [Fact]
        public void Clear_ShouldRemoveAllNotes()
        {
            var appointment = CreateMockAppointment();

            appointment.AddNote(CreateMockNote("1"))
                       .AddNote(CreateMockNote("2"));

            appointment.ClearNotes();

            Assert.Empty(appointment.GetNotes());
        }

        [Fact]
        public void Exists_ShouldReturnTrueWhenMatchFound()
        {
            var appointment = CreateMockAppointment();

            appointment.AddNote(CreateMockNote("1"));

            var exists = appointment.ExistsNote(n => n.NoteId == "1");

            Assert.True(exists);
        }

        [Fact]
        public void FindNotes_ShouldReturnMatchingNotes()
        {
            var appointment = CreateMockAppointment();

            var note1 = CreateMockNote("1");
            var note2 = CreateMockNote("2");
            var note3 = CreateMockNote("3");

            appointment.AddNote(note1)
                       .AddNote(note2)
                       .AddNote(note3);

            var result = appointment.FindNotes(n => n.NoteId != "1").ToList();

            Assert.Equal(2, result.Count);
            Assert.DoesNotContain(result, n => n.NoteId == "1");
        }

        [Fact]
        public void RemoveAll_ShouldRemoveMatchingNotes()
        {
            var appointment = CreateMockAppointment();

            appointment.AddNote(CreateMockNote("1"))
                       .AddNote(CreateMockNote("2"))
                       .AddNote(CreateMockNote("3"));

            appointment.RemoveNotes(n => n.NoteId != "1");

            Assert.Single(appointment.GetNotes());
            Assert.Equal("1", appointment.GetNotes()[0].NoteId);
        }
    }
}
