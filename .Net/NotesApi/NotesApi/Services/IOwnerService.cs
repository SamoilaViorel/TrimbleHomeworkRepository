using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Services
{
    public interface IOwnerService : ICollectionService<Owner>
    {
        List<Owner> GetOwnerByOwnerId(Guid ownerId);

    }
}
