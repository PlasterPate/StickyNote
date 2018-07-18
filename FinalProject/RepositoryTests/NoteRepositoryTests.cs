using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository.Tests
{
    [TestClass()]
    public class NoteRepositoryTests
    {
        [TestMethod()]
        public void AddNoteTest()
        {
            NoteRepository nr = new NoteRepository();
            Note testNote = new Note()
            {
                Title = "testTitle",
                Text = "testText",
                Color = "#FFFFFFFF"
            };
            Assert.IsFalse(nr.ReadAll().Contains(testNote));
            nr.AddNote(testNote);
            Assert.IsTrue(nr.ReadAll().Contains(testNote));
            nr.DeleteNote(testNote.Title);
        }

        [TestMethod()]
        public void DeleteNoteTest()
        {
            NoteRepository nr = new NoteRepository();
            Note testNote = new Note()
            {
                Title = "testTitle",
                Text = "testText",
                Color = "#FFFFFFFF"
            };
            nr.AddNote(testNote);
            Assert.IsTrue(nr.ReadAll().Contains(testNote));
            nr.DeleteNote(testNote.Title);
            Assert.IsFalse(nr.ReadAll().Contains(testNote));
        }

        [TestMethod()]
        public void ReadAllTest()
        {
            NoteRepository nr = new NoteRepository();
            List<Note> noteListTest = new List<Note>();
            for (int i = 0; i < 5; i++)
            {
                Note testNote = new Note()
                {
                    Title = $"testTitle{i}",
                    Text = $"testText{i}",
                    Color = $"#FFFFFFF{i}"
                };
                nr.AddNote(testNote);
                noteListTest.Add(testNote);
            }
            CollectionAssert.AreEqual(noteListTest, nr.ReadAll());
            for (int i = 0; i < 5; i++)
            {
                Note testNote = new Note()
                {
                    Title = $"testTitle{i}",
                    Text = $"testText{i}",
                    Color = $"#FFFFFFF{i}"
                };
                nr.DeleteNote(testNote.Title);
            }
        }
    }
}