using Task2.Domain.Entities;

namespace Task2.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderQueryResponse
    {
        public Order Order { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
