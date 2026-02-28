//using C_.Concepts.fullPractice;

//namespace C_.Concepts
//{
//    public class AppointmentPracticeVsCode
//    {
//        private static Note CreateMockNote(string id, string title = "title", string description = "desc")
//        {
//            return Note.CreateNote(id, title, description);
//        }

//        [Fact]
//        public void AddNote_ShouldAddNote_ToCollection()
//        {
//            // Arrange
//            var appointment = new Appointment();
//            var note = CreateMockNote("1");

//            // Act
//            appointment.AddNote(note);
//            // Assert
//            Assert.Contains(note, appointment.GetNotes());
//        }

//        [Fact]
//        public void AddNote_ShouldReturnSameAppointment_ForFluentChaining()
//        {
//            var appointment = new Appointment();
//            var note = CreateMockNote("1");

//            var result = appointment.AddNote(note);

//            Assert.Same(appointment, result);
//        }

//        [Fact]
//        public void AddNote_ShouldThrow_WhenNoteIsNull()
//        {
//            var appointment = new Appointment();

//            Assert.Throws<ArgumentNullException>(() => appointment.AddNote(null!));
//        }

//        [Fact]
//        public void DeleteNote_ByObject_ShouldRemoveNote()
//        {
//            var appointment = new Appointment();
//            var note = CreateMockNote("1");

//            appointment.AddNote(note);

//            appointment.DeleteNote(note);

//            Assert.DoesNotContain(note, appointment.GetNotes());
//        }

//        [Fact]
//        public void DeleteNote_ById_ShouldRemoveCorrectNote()
//        {
//            var appointment = new Appointment();
//            var note1 = CreateMockNote("1");
//            var note2 = CreateMockNote("2");

//            appointment.AddNote(note1);
//            appointment.AddNote(note2);

//            appointment.DeleteNote("1");

//            Assert.DoesNotContain(note1, appointment.GetNotes());
//            Assert.Contains(note2, appointment.GetNotes());
//        }

//        [Fact]
//        public void UpdateNote_ShouldReplaceExistingNote()
//        {
//            var appointment = new Appointment();
//            var original = CreateMockNote("1", "old", "old desc");
//            var updated = CreateMockNote("1", "new", "new desc");

//            appointment.AddNote(original);

//            appointment.UpdateNote(updated);

//            var result = appointment.GetNoteById("1");

//            Assert.Equal("new", result.Title);
//            Assert.Equal("new desc", result.Description);
//        }

//        [Fact]
//        public void UpdateNote_ShouldThrow_WhenNoteDoesNotExist()
//        {
//            var appointment = new Appointment();
//            var note = CreateMockNote("1");

//            Assert.Throws<InvalidOperationException>(() => appointment.UpdateNote(note));
//        }

//        [Fact]
//        public void GetNoteById_ShouldReturnCorrectNote()
//        {
//            var appointment = new Appointment();
//            var note = CreateMockNote("1");

//            appointment.AddNote(note);

//            var result = appointment.GetNoteById("1");

//            Assert.Equal(note, result);
//        }

//        [Fact]
//        public void GetNoteById_ShouldReturnNull_WhenNotFound()
//        {
//            var appointment = new Appointment();

//            var result = appointment.GetNoteById("999");

//            Assert.Null(result);
//        }

//        [Fact]
//        public void GetNotes_ShouldReturnAllNotes()
//        {
//            var appointment = new Appointment();
//            var note1 = CreateMockNote("1");
//            var note2 = CreateMockNote("2");

//            appointment.AddNote(note1);
//            appointment.AddNote(note2);

//            var notes = appointment.GetNotes();

//            Assert.Equal(2, notes.Count);
//        }

//        [Fact]
//        public void GetNotes_ShouldReturnReadOnlyCollection()
//        {
//            var appointment = new Appointment();
//            var note = CreateMockNote("1");

//            appointment.AddNote(note);

//            var notes = appointment.GetNotes();

//            Assert.IsAssignableFrom<IReadOnlyList<Note>>(notes);
//        }

//        [Fact]
//        public void Notes_Property_ShouldExposeReadOnlyCollection()
//        {
//            var appointment = new Appointment();
//            var note = CreateMockNote("1");

//            appointment.AddNote(note);

//            Assert.Contains(note, appointment.Notes);
//        }
//    }
//}
