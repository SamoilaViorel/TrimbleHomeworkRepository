using MongoDB.Driver;
using NotesApi.Models;
using NotesApi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Services
{
    public class OwnerService:IOwnerService
    {
        private readonly IMongoCollection<Owner> _owner;

        public OwnerService(IMongoDBSettingsOwner settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _owner = database.GetCollection<Owner>(settings.OwnerCollectionName);
        }

        public async Task<bool> Create(Owner model)
        {
            await _owner.InsertOneAsync(model);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _owner.DeleteOneAsync(owner => owner.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<Owner> Get(Guid id)
        {
            return (await _owner.FindAsync(owner => owner.Id == id)).FirstOrDefault();
        }

        public async Task<List<Owner>> GetAll()
        {
            var result = await _owner.FindAsync(note => true);
            return result.ToList();
        }

        public async Task<bool> Update(Guid id, Owner model)
        {
            model.Id = id;
            var result = await _owner.ReplaceOneAsync(note => note.Id == id, model);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _owner.InsertOneAsync(model);
                return false;
            }

            return true;
        }
    }
}
