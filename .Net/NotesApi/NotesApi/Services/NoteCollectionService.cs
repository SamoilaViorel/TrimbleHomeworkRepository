using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Services
{
    public class NoteCollectionService : INoteCollectionService
    {

        private List<Notes> _notes = new List<Notes> { new Notes { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        new Notes { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        new Notes { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        new Notes { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Notes { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
        };


        public NoteCollectionService()
        {

        }

        public bool Create(Notes model)
        {
            _notes.Add(model);
            bool isAdded = _notes.Contains(model);
            return isAdded;
        }

        public bool Delete(Guid id)
        {
            bool isDeleted;
            var note = _notes.FirstOrDefault(c => c.Id == id);

            if (note != null)
            {
                _notes.Remove(note);
                isDeleted = true;
            }
            else
            {
                isDeleted = false;
            }

            return isDeleted;

        }

        public Notes Get(Guid id)
        {
            //return _notes.Where(c => c.Id == id).FirstOrDefault();
            return _notes.FirstOrDefault(c => c.Id == id);
        }

        public List<Notes> GetAll()
        {
            return _notes;
        }

        public List<Notes> GetNotesByOwnerId(Guid ownerId)
        {
            return (_notes.FindAll(note => note.OwnerId == ownerId));
        }

        public bool Update(Guid id, Notes model)
        {

            //_notes
            //    .Where(c => c.Id == id)
            //    .ToList()
            //    .ForEach(c =>
            //    {
            //        c.Id = model.Id;
            //        c.OwnerId = model.OwnerId;
            //        c.Title = model.Title;
            //        c.Description = model.Description;
            //        c.CategoryId = model.CategoryId;
            //    });



            bool isUpdated;

            int index = _notes.FindIndex(c => c.Id == id);


            if (index != -1)
            {
                _notes[index] = model;

                isUpdated = true;
            }
            else
            {
                isUpdated = false;
            }

            return isUpdated;
        }
    }
}
