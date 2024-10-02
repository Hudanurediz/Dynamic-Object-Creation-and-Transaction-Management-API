using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductQueryResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
