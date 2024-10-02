using MediatR;

namespace Task2.Application.Features.Customers.Queries.SearchCustomer
{
    public class SearchCustomerQueryRequest:IRequest<SearchCustomerQueryResponse>
    {
        public string Property { get; set; }
    }
}
