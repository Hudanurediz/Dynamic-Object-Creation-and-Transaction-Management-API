using MediatR;
using Task2.Domain.Entities;

namespace Task2.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductQueryRequest:IRequest<CreateProductQueryResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string BarcodeCode { get; set; }

        public string Brand { get; set; }

        public int StockQuantity { get; set; }

        public ICollection<OrderProduct>? OrderProducts { get; set; }

    }
}
