using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Settings
{
    public class MongoDBSettingsOwner : IMongoDBSettingsOwner
    {
        public string OwnerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
