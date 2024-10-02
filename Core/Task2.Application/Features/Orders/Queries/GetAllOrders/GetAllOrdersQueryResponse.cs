using Task2.Domain.Entities;

namespace Task2.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryResponse
    {
        public List<Order> Orders { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
