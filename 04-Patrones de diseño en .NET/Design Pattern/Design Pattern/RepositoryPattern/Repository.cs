using Design_Pattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.RepositoryPattern
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DesignPatternsContext _context;
        private DbSet<TEntity> _dbSet;
        public Repository(DesignPatternsContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var dataToDelete = _dbSet.Find(id);
            _dbSet.Remove(dataToDelete);
        }

        public TEntity Get(int id) => _dbSet.Find(id);

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
    }
}
