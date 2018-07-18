using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Business.Tests
{
    [TestClass()]
    public class NoteLogicTests
    {
        [TestMethod()]
        public void AddNoteTest()
        {
            NoteLogic nl = new NoteLogic();
            NoteViewModel testNoteViewModel = new NoteViewModel()
            {
                Title = "testTitle",
                Text = "testText",
                Color = "#ffffffff"
            };
            nl.AddNote(testNoteViewModel);
            Assert.AreEqual(nl.noteRepository.Find(testNoteViewModel.Title).Title, testNoteViewModel.Title);
            Assert.AreEqual(nl.noteRepository.Find(testNoteViewModel.Title).Text, testNoteViewModel.Text);
            Assert.AreEqual(nl.noteRepository.Find(testNoteViewModel.Title).Color, testNoteViewModel.Color);
            nl.DeleteNote(testNoteViewModel.Title);
        }

        [TestMethod()]
        public void DeleteNoteTest()
        {
            NoteLogic nl = new NoteLogic();
            NoteViewModel testNoteViewModel = new NoteViewModel()
            {
                Title = "testTitle",
                Text = "testText",
                Color = "#ffffffff"
            };
            nl.AddNote(testNoteViewModel);
            nl.DeleteNote(testNoteViewModel.Title);
            Assert.IsFalse(nl.ReadAll().Contains(testNoteViewModel));
        }
    }
}