using Application.Abstractions;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class BrandRepository : IRepository<BrandEntity>
    {
        private StoreFsContext _context;
        public BrandRepository(StoreFsContext context)
        {
            _context = context;
        }
        public async Task AddAsync(BrandEntity entity)
        {
            var brand = MapToModel(entity);
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null) throw new KeyNotFoundException("El id no existe");

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<BrandEntity>> GetAllAsync()
        {
            var brands = await _context.Brands.ToListAsync();
            return brands.Select(MapToEntity);
        }
        public async Task<BrandEntity> GetByIdAsync(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);
            if (brand == null) throw new KeyNotFoundException("El id no existe");
            return MapToEntity(brand);
        }
        public async Task UpdateAsync(BrandEntity entity)
        {
            if (entity.Id is null) throw new ArgumentException("Id es requerido", nameof(entity));
            var brand = await _context.Brands.FindAsync(entity.Id);
            if (brand == null) throw new KeyNotFoundException("El id no existe");

            brand.Name = entity.Name;

            await _context.SaveChangesAsync();
        }
        #region Mappers
        private static BrandEntity MapToEntity(Brand model)
        {
            return new BrandEntity(model.Id, model.Name);
        }

        private static Brand MapToModel(BrandEntity entity)
        {
            return new Brand
            {
                Id = entity.Id ?? 0,
                Name = entity.Name
            };
        }
        #endregion
    }
}
