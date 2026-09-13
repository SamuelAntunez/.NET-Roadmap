using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Sale.DTOs
{
    public class SaleDto
    {
        public int? Id { get;  set; }
        public DateTime Date { get;  set; }

        public List<SaleDetailDto> Details { get; set; } = new List<SaleDetailDto>();

        public decimal Total => Details?.Sum(d => d.TotalPrice) ?? 0;
    }
}
