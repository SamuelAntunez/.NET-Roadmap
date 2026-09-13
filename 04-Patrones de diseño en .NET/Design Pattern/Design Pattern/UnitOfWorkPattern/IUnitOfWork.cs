using Design_Pattern.Models;
using Design_Pattern.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        public IRepository<Beer> Beers { get; }
        public IRepository<Brand> Brands { get; }
        public void Save();
    }
}
