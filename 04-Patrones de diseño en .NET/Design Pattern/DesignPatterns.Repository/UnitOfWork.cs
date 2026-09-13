using DesignPatterns.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DesignPatternsContext _context;
        private IRepository<Beer> _beers;
        private IRepository<Brand> _brands;
        public UnitOfWork(DesignPatternsContext context)
        {
            _context = context;
        }
        public IRepository<Beer> Beers
        {
            get
            {
                return _beers == null
                    ? _beers = new Repository<Beer>(_context)
                    : _beers;
            }
        }
        public IRepository<Brand> Brands
        {
            get
            {
                return _brands == null
                    ? _brands = new Repository<Brand>(_context)
                    : _brands;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
