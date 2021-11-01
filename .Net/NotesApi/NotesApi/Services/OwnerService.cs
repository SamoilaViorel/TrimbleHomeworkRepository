using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Services
{
    public class OwnerService : IOwnerService
    {
        List<Owner> _ownerList = new List<Owner>()
        {
            new Owner(){ Id = new Guid("00000000-0000-0000-0000-000000000001"), Name="Ana"},
            new Owner(){ Id = new Guid("00000000-0000-0000-0000-000000000002"), Name="Emil"},
            new Owner(){ Id = new Guid("00000000-0000-0000-0000-000000000003"), Name="Ion"}
        };

        public bool Create(Owner model)
        {
            _ownerList.Add(model);
            return (_ownerList.Contains(model));
        }

        public bool Delete(Guid id)
        {
            bool isDeleted;
            var note = _ownerList.FirstOrDefault(c => c.Id == id);

            if (note != null)
            {
                _ownerList.Remove(note);
                isDeleted = true;
            }
            else
            {
                isDeleted = false;
            }

            return isDeleted;
        }

        public Owner Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Owner> GetAll()
        {
            return _ownerList;
        }

        public List<Owner> GetOwnerByOwnerId(Guid ownerId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, Owner model)
        {
            bool isUpdated;

            int index = _ownerList.FindIndex(c => c.Id == id);


            if (index != -1)
            {
                _ownerList[index] = model;

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
