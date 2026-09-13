using Application.Abstractions;
using Application.Product.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Product.UseCases
{
    public class UpdateProductUseCase : IUpdateUseCase<ProductDto, ProductEntity>
    {
        private readonly IUpdateRepository<ProductEntity> _repository;
        private readonly IMapper<ProductDto, ProductEntity> _mapper;
        public UpdateProductUseCase(IUpdateRepository<ProductEntity> repository, IMapper<ProductDto, ProductEntity> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task UpdateAsync(ProductDto dto, int id)
        {
            var productEntity = _mapper.Map(dto);
            await _repository.UpdateAsync(productEntity, id);
        }
    }
}
