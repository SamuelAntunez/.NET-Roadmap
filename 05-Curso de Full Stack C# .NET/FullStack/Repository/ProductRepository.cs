using Application.Abstractions;
using Application.Product.DTOs;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductRepository : IReadRepository<ProductEntity>, ICreateRepository<ProductEntity>, IUpdateRepository<ProductEntity>, IDeleteRepository
    {
        private StoreFsContext _context;
        public ProductRepository(StoreFsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products.Select(MapToEntity);
        }

        public async Task<ProductEntity> GetByIdAsnyc(int id)
        {
            
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new KeyNotFoundException($"Producto no existe {id}");
            return MapToEntity(product);
        }

        public async Task AddAsnyc(ProductEntity entity)
        {
            var product = MapToModel(entity);
            product.Date = DateTime.UtcNow;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductEntity entity, int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new KeyNotFoundException($"El producto con id {id} no existe");
            MapToModel(entity, product);
            await _context.SaveChangesAsync();
            
           
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new KeyNotFoundException($"El producto con id {id} no existe");


            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        #region Mapper
        private static ProductEntity MapToEntity(Product model)
        {
            return new ProductEntity(model.Id, model.Name, model.Cost, model.Price, model.Active, model.BrandId);

        }

        private static Product MapToModel(ProductEntity entity)
        {
            return new Product
            {
                Name = entity.Name,
                Cost = entity.Cost,
                Price = entity.Price,
                Active = entity.Active,
                BrandId = entity.BrandId
            };
        }

        private static void MapToModel(ProductEntity entity, Product product)
        {
            product.Name = entity.Name;
            product.Cost = entity.Cost;
            product.Price = entity.Price;
            product.Active = entity.Active;
            product.BrandId = entity.BrandId;
        }
        #endregion
    }
}
