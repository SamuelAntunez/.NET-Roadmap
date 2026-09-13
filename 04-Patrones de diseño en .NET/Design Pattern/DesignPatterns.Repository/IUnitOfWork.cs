using DesignPatterns.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Repository
{
    public interface IUnitOfWork
    {
        
            public IRepository<Beer> Beers { get; }
            public IRepository<Brand> Brands { get; }
            public void Save();
        
    }
}
