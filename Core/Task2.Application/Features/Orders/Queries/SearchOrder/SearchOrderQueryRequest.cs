using MediatR;

namespace Task2.Application.Features.Orders.Queries.SearchOrder
{
    public class SearchOrderQueryRequest:IRequest<SearchOrderQueryResponse>
    {
        public string Property { get; set; }
    }
}
