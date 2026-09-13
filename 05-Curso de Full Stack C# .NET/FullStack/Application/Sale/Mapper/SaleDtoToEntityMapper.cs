using Application.Abstractions;
using Application.Sale.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Sale.Mapper
{
    internal class SaleDtoToEntityMapper : IMapper<SaleDto, SaleEntity>
    {
        public SaleEntity Map(SaleDto input)
        {
            if (input == null) throw new ArgumentException(nameof(input));
            var saleEntity = new SaleEntity(input.Date, input.Id);

            if (input.Details != null)
            {
                foreach (var detailDto in input.Details)
                {
                    var detailEntity = new SaleDetailEntity(input.Id, detailDto.ProductId, detailDto.Quantity, detailDto.UnitPrice, detailDto.Id);
                    saleEntity.Details.Add(detailEntity);
                }

            }

            return saleEntity;
        }
    }
}
