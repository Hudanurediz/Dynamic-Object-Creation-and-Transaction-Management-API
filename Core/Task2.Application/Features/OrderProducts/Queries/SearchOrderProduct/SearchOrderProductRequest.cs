using MediatR;

namespace Task2.Application.Features.OrderProducts.Queries.SearchOrderProduct
{
    public class SearchOrderProductRequest:IRequest<SearchOrderProductResponse>
    {
        public string? Property { get; set; }
    }
}
