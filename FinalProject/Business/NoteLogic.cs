using Repository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Business
{
    public class NoteLogic
    {
        public NoteRepository noteRepository = new NoteRepository();
        public void AddNote(NoteViewModel noteViewModel)
        {
            Note note = new Note();
            note.Text = noteViewModel.Text;
            note.Title = noteViewModel.Title;
            note.Color = noteViewModel.Color;
            noteRepository.AddNote(note);
        }

        public void DeleteNote(string noteTitle)
        {
            noteRepository.DeleteNote(noteTitle);
        }

        public List<NoteViewModel> ReadAll()
        {
            List<NoteViewModel> nvmList = new List<NoteViewModel>();
            foreach(var note in noteRepository.ReadAll())
            {
                NoteViewModel nvm = new NoteViewModel();
                nvm.Text = note.Text;
                nvm.Title = note.Title;
                nvm.Color = note.Color;
                nvmList.Add(nvm);
            }
            return nvmList;
        }

        public NoteViewModel Find(string title)
        {
            NoteViewModel nvm = new NoteViewModel();
            nvm.Text = noteRepository?.Find(title).Text;
            nvm.Title = noteRepository?.Find(title).Title;
            nvm.Color = noteRepository?.Find(title).Color;
            return nvm;
        }
    }
}
