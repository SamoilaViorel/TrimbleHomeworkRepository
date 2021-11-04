using MongoDB.Driver;
using NotesApi.Models;
using NotesApi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Services
{
    public class NoteCollectionService : INoteCollectionService
    {

        private readonly IMongoCollection<Notes> _notes;

        public NoteCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _notes = database.GetCollection<Notes>(settings.NoteCollectionName);
        }


        public async Task<List<Notes>> GetAll()
        {
            var result = await _notes.FindAsync(note => true);
            return result.ToList();
        }

        public async Task<bool> Create(Notes note)
        {
            await _notes.InsertOneAsync(note);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _notes.DeleteOneAsync(note => note.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<Notes> Get(Guid id)
        {
            return (await _notes.FindAsync(note => note.Id == id)).FirstOrDefault();
        }

        public async Task<bool> Update(Guid id, Notes note)
        {
            note.Id = id;
            var result = await _notes.ReplaceOneAsync(note => note.Id == id, note);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _notes.InsertOneAsync(note);
                return false;
            }

            return true;
        }

        public async Task<List<Notes>> GetNotesByOwnerId(Guid ownerId)
        {
            return (await _notes.FindAsync(note => note.OwnerId == ownerId)).ToList();
        }

    }
}
