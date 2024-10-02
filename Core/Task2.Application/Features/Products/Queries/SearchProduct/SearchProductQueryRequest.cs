using MediatR;

namespace Task2.Application.Features.Products.Queries.SearchProduct
{
    public class SearchProductQueryRequest:IRequest<SearchProductQueryResponse>
    {
        public string? Property {  get; set; }
    }
}
