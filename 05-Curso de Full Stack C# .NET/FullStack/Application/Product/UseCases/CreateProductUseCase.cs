using Application.Abstractions;
using Application.Product.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Product.UseCases
{
    public class CreateProductUseCase : ICreateUseCase<ProductDto, ProductEntity>
    {
        private readonly ICreateRepository<ProductEntity> _repository;
        private readonly IMapper<ProductDto, ProductEntity> _mapper;

        public CreateProductUseCase(ICreateRepository<ProductEntity> repository, IMapper<ProductDto, ProductEntity> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddAsync(ProductDto dto)
        {
            var productEntity = _mapper.Map(dto);
            await _repository.AddAsnyc(productEntity);
        }
    }
}
