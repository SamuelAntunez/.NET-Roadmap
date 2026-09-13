using Design_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.RepositoryPattern
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> Get();
        Beer Get(int id);
        void Add(Beer data);
        void Delete(int id);
        void Update(Beer data);
        void Save();
    }
}
