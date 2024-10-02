using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Domain.Entities;

namespace Task2.Application.Features.OrderProducts.Queries.GetByIdOrderProduct
{
    public class GetByIdOrderProductResponse
    {
        public OrderProduct OrderProduct { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
