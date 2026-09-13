using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Abstractions
{
    public interface IReadRepository<TEntity>
    {
        public Task<TEntity> GetByIdAsnyc(int id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
