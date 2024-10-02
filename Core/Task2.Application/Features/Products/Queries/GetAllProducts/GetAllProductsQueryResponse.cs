using Task2.Domain.Entities;

namespace Task2.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public List<Product> Products { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
