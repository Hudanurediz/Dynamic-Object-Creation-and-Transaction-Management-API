using Task2.Domain.Entities;

namespace Task2.Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductQueryResponse
    {
        public Product Product { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
