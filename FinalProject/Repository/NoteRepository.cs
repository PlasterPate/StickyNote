using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NoteRepository
    {
        public Context Context;
        public NoteRepository()
        {
            Context = new Context();
        }

        public void AddNote(Note note)
        {
            Context.Notes.Add(note);
            Context.SaveChanges();
        }

        public void DeleteNote(string note)
        {
            Context.Notes.Remove(Context.Notes.Find(note));
            Context.SaveChanges();
        }

        public List<Note> ReadAll()
        {
            return Context.Notes.ToList();
        }

        public Note Find(string title)
        {
            return Context.Notes.Find(title);
        }
    }
}
