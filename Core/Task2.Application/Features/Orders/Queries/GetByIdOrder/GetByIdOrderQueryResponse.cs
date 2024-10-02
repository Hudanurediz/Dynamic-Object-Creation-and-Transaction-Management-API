using Task2.Domain.Entities;

namespace Task2.Application.Features.Orders.Queries.GetByIdOrder
{
    public class GetByIdOrderQueryResponse
    {
        public Order Order { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
