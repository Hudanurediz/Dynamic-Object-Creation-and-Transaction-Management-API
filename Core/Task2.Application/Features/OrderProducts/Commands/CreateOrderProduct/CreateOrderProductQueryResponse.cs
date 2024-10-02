using Task2.Domain.Entities;

namespace Task2.Application.Features.OrderProducts.Commands.CreateOrderProduct
{
    public class CreateOrderProductQueryResponse
    {
        public OrderProduct? OrderProduct { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
