using Task2.Domain.Entities;

namespace Task2.Application.Features.OrderProducts.Queries.GetAllOrderProducts
{
    public class GetAllOrderProductsQueryResponse
    {
        public List<OrderProduct> OrderProducts { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
