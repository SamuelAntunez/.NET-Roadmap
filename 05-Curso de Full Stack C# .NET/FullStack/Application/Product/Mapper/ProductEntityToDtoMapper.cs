using Application.Abstractions;
using Application.Product.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Product.Mapper
{
    public class ProductEntityToDtoMapper : IMapper<ProductEntity, ProductDto>
    {
        public ProductDto Map(ProductEntity entity)
        {
            if(entity == null) throw new ArgumentNullException(nameof(entity));
            return new ProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Cost = entity.Cost,
                Price = entity.Price,
                Active = entity.Active,
                BrandId = entity.BrandId,
            };
        }
    }
}
