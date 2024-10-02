using Task2.Domain.Entities;

namespace Task2.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductQueryResponse
    {
        public Product Product { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
