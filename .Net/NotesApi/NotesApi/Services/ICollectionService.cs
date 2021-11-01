using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Services
{
    public interface ICollectionService<T>
    {
        List<T> GetAll();

        T Get(Guid id);

        bool Create(T model);

        bool Update(Guid id, T model);

        bool Delete(Guid id);

    }
}
