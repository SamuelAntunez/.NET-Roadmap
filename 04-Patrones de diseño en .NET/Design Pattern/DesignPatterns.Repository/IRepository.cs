using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Repository
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Delete(int id);
        void Update(TEntity data);
        void Save();
    }
}
