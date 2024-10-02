using Task2.Domain.Entities;

namespace Task2.Application.Features.Orders.Queries.SearchOrder
{
    public class SearchOrderQueryResponse
    {
        public List<Order> Orders { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
