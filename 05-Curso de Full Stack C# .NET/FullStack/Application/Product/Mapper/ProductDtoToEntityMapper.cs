using Application.Abstractions;
using Application.Product.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Product.Mapper
{
    public class ProductDtoToEntityMapper : IMapper<ProductDto, ProductEntity>
    {
        public ProductEntity Map(ProductDto dto)
        {
            return dto.Id == null ? new ProductEntity(dto.Name, dto.Cost, dto.Price, dto.Active, dto.BrandId)
                                  : new ProductEntity((int)dto.Id, dto.Name, dto.Cost, dto.Price, dto.Active, dto.BrandId);
        }
    }
}
