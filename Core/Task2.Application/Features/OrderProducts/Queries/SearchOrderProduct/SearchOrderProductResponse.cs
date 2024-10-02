using Task2.Domain.Entities;

namespace Task2.Application.Features.OrderProducts.Queries.SearchOrderProduct
{
    public class SearchOrderProductResponse
    {
        public List<OrderProduct> OrderProducts { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
